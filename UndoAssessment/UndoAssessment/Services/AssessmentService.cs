using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services.Interfaces;
using UndoAssessment.Utilities;

namespace UndoAssessment.Services
{
    public class AssessmentService : IAssessmentService
    {
        HttpClient _client;

        public AssessmentService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://malkarakundostagingpublicapi.azurewebsites.net/");
        }
        #region example with generic type, error handling
        public async Task<ApiResponse<T>> CallApi<T>(string url)
        {
            var response = await _client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new CustomDateTimeConverter());
            if (response.IsSuccessStatusCode)
            {
                return new ApiResponse<T>
                {
                    IsSuccess = true,
                    Data = JsonConvert.DeserializeObject<T>(result, settings)
                };
            }
            else
            {
                var errorResponse = JsonConvert.DeserializeObject<FailResult>(result, settings);
                return new ApiResponse<T>
                {
                    IsSuccess = false,
                    ErrorCode = errorResponse.ErrorCode,
                    ErrorMessage = errorResponse.Message
                };
            }
        }
        #endregion


    }
}
