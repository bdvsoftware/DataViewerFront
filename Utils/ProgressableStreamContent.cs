using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Utils
{
    public class ProgressableStreamContent : HttpContent
    {
        private readonly Stream _content;
        private readonly int _bufferSize;
        private readonly Action<int> _progressCallback;

        public ProgressableStreamContent(Stream content, int bufferSize, Action<int> progressCallback)
        {
            _content = content;
            _bufferSize = bufferSize;
            _progressCallback = progressCallback;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var buffer = new byte[_bufferSize];
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = await _content.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await stream.WriteAsync(buffer, 0, bytesRead);
                totalBytesRead += bytesRead;

                var percent = (int)((totalBytesRead * 100L) / _content.Length);
                _progressCallback?.Invoke(percent);
            }
        }

        protected override bool TryComputeLength(out long length)
        {
            length = _content.Length;
            return true;
        }
    }
}
