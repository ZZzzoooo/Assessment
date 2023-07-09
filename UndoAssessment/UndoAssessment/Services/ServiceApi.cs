using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
	public class ServiceApi: IServiceApi
	{
        const string UrlBaseAddress = "https://malkarakundostagingpublicapi.azurewebsites.net";
        private HttpClient _client;

        public ServiceApi()
		{
            _client = new HttpClient()
            {
                BaseAddress = new Uri(UrlBaseAddress)
            };
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }        

        public async Task<SuccessfulResponse> RequestSuccess()
        {
            SuccessfulResponse responseSuccessful = new SuccessfulResponse();

            try
            {
                var response = await _client.GetAsync("/success");
                string ret = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(ret))
                {
                    responseSuccessful = JsonConvert.DeserializeObject<SuccessfulResponse>(ret);
                    return responseSuccessful;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseSuccessful;
        }

        public async Task<FailureResponse> RequestFailure()
        {
            FailureResponse responseFailure = new FailureResponse();

            try
            {
                var response = await _client.GetAsync("fail");
                string ret = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(ret))
                {
                    responseFailure = JsonConvert.DeserializeObject<FailureResponse>(ret);
                    return responseFailure;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return responseFailure;
        }
    }
}