using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class TestService
    {
        private readonly string _api1Endpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
        private readonly string _api2Endpoint = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";

        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<HttpResponse> GetSuccess()
        {
            return await this.CommonHttpRequest(_api1Endpoint);
        }

        public async Task<HttpResponse> GetFailure()
        {
            return await this.CommonHttpRequest(_api2Endpoint);
        }

        public async Task<HttpResponse> CommonHttpRequest(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HttpResponse>(content);
        }
    }
}