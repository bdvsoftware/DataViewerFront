using System.Net.Http.Headers;
using DataViewerFront.Utils;

namespace DataViewerFront.Services
{
    internal class VideoService : BaseService
    {

        private string _videoUrl;

        public VideoService() {
            _videoUrl = _apiUrl + "/video";
        }

        public async Task UploadFileAsync(string filePath, string gpName, string sessionName, Action<int> progressCallback)
        {
            try
            {
                using var form = new MultipartFormDataContent();
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                var streamContent = new ProgressableStreamContent(fileStream, 4096, progressCallback);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(streamContent, "file", Path.GetFileName(filePath));
                form.Add(new StringContent(gpName), "grandPrixName");
                form.Add(new StringContent(sessionName), "sessionName");

                var response = await _httpClient.PostAsync(_videoUrl + "/upload", form);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error en la subida. Código: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error durante la subida: " + ex.Message);
            }
        }
    }
}
