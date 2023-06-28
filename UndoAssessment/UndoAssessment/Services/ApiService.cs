// ApiService.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public class ApiService
    {
        private const string SuccessEndpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
        private const string FailEndpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";

        public async Task<string> InvokeSuccessApi()
        {
            return await InvokeApiEndpoint(SuccessEndpoint);
        }

        public async Task<string> InvokeFailApi()
        {
            return await InvokeApiEndpoint(FailEndpoint);
        }

        private async Task<string> InvokeApiEndpoint(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(endpoint);
                    var content = await response.Content.ReadAsStringAsync();
                    return response.IsSuccessStatusCode ? content : throw new Exception(content);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
