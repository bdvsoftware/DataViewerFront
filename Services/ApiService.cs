using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataViewerFront.Utils;

namespace DataViewerFront.Services
{
    internal class ApiService
    {
        private readonly string _apiUrl = "http://localhost:5228/api";

        private readonly HttpClient _httpClient = new HttpClient();

        public async Task UploadFileAsync(string filePath, Action<int> progressCallback)
        {
            try
            {
                using var client = new HttpClient();
                using var form = new MultipartFormDataContent();
                using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                var streamContent = new ProgressableStreamContent(fileStream, 4096, progressCallback);

                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                form.Add(streamContent, "file", Path.GetFileName(filePath)); // cambia esto según tu backend

                var response = await client.PostAsync(_apiUrl+"/video/upload", form);
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
