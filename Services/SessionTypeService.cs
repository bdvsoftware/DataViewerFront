using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataViewerFront.Services
{
    internal class SessionTypeService : BaseService
    {

        private readonly string _sessionTypesUrl;

        public SessionTypeService()
        {
            _sessionTypesUrl = _apiUrl + "/sessiontype";
        }

        public async Task<List<string>> GetAllSessionTypeNamesAsync()
        {
            var response = await _httpClient.GetAsync(_sessionTypesUrl + "/all-names");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error retrieving session types: " + response.StatusCode);
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

    }
}
