using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services.Interfaces;

namespace UndoAssessment.Services
{
    public class ApiService : IApiService
    {
        const string BaseAddress = "https://malkarakundostagingpublicapi.azurewebsites.net";

        private HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseAddress)
            };
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<FailResponse> GetFail()
        {
            try
            {
                var response = await _httpClient.GetAsync("/fail");
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseBody))
                {
                    var failResponse = JsonConvert.DeserializeObject<FailResponse>(responseBody);
                    return failResponse;
                }
            }
            catch (Exception ex)
            {
                return default;
            }

            return default;
        }

        public async Task<SuccessResponse> GetSuccess()
        {
            try
            {
                var response = await _httpClient.GetAsync("/success");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(responseBody))
                {
                    var successResponse = JsonConvert.DeserializeObject<SuccessResponse>(responseBody);
                    return successResponse;
                }
            }
            catch (Exception ex)
            {
                return default;
            }

            return default;
        }
    }
}
