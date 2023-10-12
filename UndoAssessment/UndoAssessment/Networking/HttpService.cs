using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UndoAssessment.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Text.Json;

namespace UndoAssessment.Networking
{
	
    public class HttpService : IHttpService
    {
        private readonly JsonSerializerOptions _options;
        public HttpService()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNamingPolicy= JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ApiResponse> GetAsync<TResult>(string uri)
        {
            try
            {
                if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    //NO network
                }
                HttpClient httpClient = CreateHttpClient();
                var response = await httpClient.GetAsync(uri);

                string serialized = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ApiResponse>(serialized, _options);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}

