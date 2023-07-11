using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.DataProvider
{
    internal class DataProvider : IDataProvider
    {
        private const string Url = "https://malkarakundostagingpublicapi.azurewebsites.net/";
        private const string SuccessPartUrl = "success";
        private const string FailPartUrl = "fail";

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = Enumerable.Range(0, 11).Select(ind => new Item() { Id = ind.ToString(), Text = ind.ToString(), Description = ind.ToString() });

            return await Task.FromResult(items);
        }

        public async Task<ApiResponse> MakeApiRequest(bool flag)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var urlformat = $"Url/{(flag ? SuccessPartUrl : FailPartUrl)}";


                    var response = await client.GetAsync(urlformat);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = ParseResponse(responseBody);

                        return new ApiResponse
                        {
                            IsSuccess = true,
                            Result = result
                        };
                    }
                    else
                    {
                        // Read the error message from the response
                        var errorMessage = await response.Content.ReadAsStringAsync();

                        // Return an error result with the error message
                        return new ApiResponse
                        {
                            IsSuccess = false,
                            ErrorMessage = errorMessage
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        private static ApiResponseModel ParseResponse(string responseBody)
        {
            return new ApiResponseModel()
            {
                Id = 11,
                Name = "fff"
            };
        }
    }
}
