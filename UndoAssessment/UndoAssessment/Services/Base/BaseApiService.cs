using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Base
{
    public class BaseApiService
    {
        protected async Task<string> InvokeEndpoint(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException ex)
            {
                var content = ex.Message;
                throw new ApiRequestException(content);
            }
        }

        protected ApiResponseModel ExtractApiResponse(string response)
        {
            try
            {
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel>(response);
                return apiResponse;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to deserialize API response: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to extract API response: {ex.Message}");
                return null;
            }
        }
    }
}
