using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class DataRepository
    {
        private const string SuccessUrl = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
        private const string FailUrl = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";

        private HttpClient client;
        private IAsyncPolicy<HttpResponseMessage> defaultPolicy;

        public DataRepository()
        {
            client = new HttpClient();
            defaultPolicy = GetRetryPolicy();
        }

        public async Task<SuccessfulMessage> GetSuccess(CancellationToken cancellationToken)
        {
            var result = await ExecuteCall(SuccessUrl, cancellationToken);

            return await ReadData<SuccessfulMessage>(result);
        }

        public async Task<FailedMessage> GetFailed(CancellationToken cancellationToken)
        {
            var result = await ExecuteCall(FailUrl, cancellationToken);

            return await ReadData<FailedMessage>(result);
        }

        private async Task<HttpResponseMessage> ExecuteCall(string url, CancellationToken cancellationToken)
        {
            return await defaultPolicy.ExecuteAsync(async () => await client.GetAsync(url, cancellationToken));
        }

        private async Task<T> ReadData<T>(HttpResponseMessage responseMessage)
        {
            var data = await responseMessage.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(data);
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            //We can make stricter policies in future to prevent failed requests...
            return Policy
                .HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(2), (result, timeSpan, retryCount, context) =>
                {
                    //Logging placeholder
                    System.Diagnostics.Debug.WriteLine($"Request failed with {result.Result.StatusCode}. Waiting {timeSpan} before next retry. Retry attempt {retryCount}");
                });
        }
    }
}
