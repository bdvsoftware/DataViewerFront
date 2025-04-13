using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewerFront.Services
{
    internal class BaseService
    {
        protected readonly string _apiUrl = "http://localhost:5228/api";

        protected readonly HttpClient _httpClient = new HttpClient();
    }
}
