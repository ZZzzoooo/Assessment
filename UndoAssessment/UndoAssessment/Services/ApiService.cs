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
    public class ApiService
    {
        private static readonly String baseUrl  = "https://malkarakundostagingpublicapi.azurewebsites.net/";
        private static readonly String success  = baseUrl + "success";
        private static readonly String fail     = baseUrl + "fail";

        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<ApiResponseModel> GetSuccess()
        {
            return await httpRequest(success);
        }

        public static async Task<ApiResponseModel> GetFail()
        {
            return await httpRequest(fail);
        }

        private static async Task<ApiResponseModel> httpRequest(string endpoint)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            String content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ApiResponseModel>(content);
        }
    }
}