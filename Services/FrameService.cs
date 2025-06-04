using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataViewerFront.Dtos;

namespace DataViewerFront.Services
{
    internal class FrameService : BaseService
    {
        private string _frameUrl;

        public FrameService()
        {
            _frameUrl = _apiUrl + "/frame";
        }

        public async Task UpdateFrameData(int? videoId, int timestamp, int lap, string driverAbbr)
        {
            var requestDto = new UpdateFrameRequestDto(videoId, timestamp, lap, driverAbbr);

            var json = JsonSerializer.Serialize(requestDto);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_frameUrl + "/update", body);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Frame updated.");
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error: {response.StatusCode}\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling API: " + ex.Message);
            }
        }
    }
}
