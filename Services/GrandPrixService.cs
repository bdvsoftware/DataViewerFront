using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataViewerFront.Services
{
    internal class GrandPrixService : BaseService
    {
        private readonly string _grandPrixUrl;

        public GrandPrixService()
        {
            _grandPrixUrl = _apiUrl + "/grandprix";
        }

        public async Task<List<string>> GetAllGrandPrixNamesAsync()
        {
            var response = await _httpClient.GetAsync(_grandPrixUrl + "/all-names");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving GP names: " + response.StatusCode);
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }


    }
}
