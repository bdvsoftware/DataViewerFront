using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text.Json;
using DataViewerFront.Dtos;
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

        public async Task<IEnumerable<ResponseVideoDto>> GetVideos()
        {
            var response = await _httpClient.GetAsync(_videoUrl+"/all");
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ResponseVideoDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task ProcessVideo(int? videoId)
        {
            if(videoId != null)
            {
                var response = await _httpClient.PostAsync(_videoUrl + "/process/" + videoId, null);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error while processing. Código: {response.StatusCode}");
                }
            }else
            {
                throw new Exception("No video selected");
            }
        }

        public async Task<Dictionary<string, DriverVideoDto>> GetVideoData(int? videoId)
        {
            if (videoId != null)
            {
                var response = await _httpClient.GetAsync(_videoUrl + "/data/" + videoId);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<Dictionary<string, DriverVideoDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return data;
                }
                return null;
            }
            else
            {
                throw new Exception("No video selected"); ;
            }
        }

        public async Task<string> DownloadVideoAsync(int? videoId)
        {
            try
            {
                string projectTempPath = Path.Combine("C:/racing/DataViewerFront/Temp/");

                Directory.CreateDirectory(projectTempPath);

                string filePath = "";

                using (HttpResponseMessage response = await _httpClient.GetAsync(_videoUrl + "/download/" + videoId))
                {
                    response.EnsureSuccessStatusCode();

                    var fileName = response.Content.Headers.ContentDisposition.FileName?.Trim('"') ?? "default.mp4";

                    filePath = Path.Combine(projectTempPath, fileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }

                MessageBox.Show($"Video descargado correctamente en: {filePath}");
                return filePath;
            }
            catch(Exception ex)
            {
                throw new Exception("Error downloading video");
            }
        }
    }
}
