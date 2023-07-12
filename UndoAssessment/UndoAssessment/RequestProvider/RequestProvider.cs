using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace UndoAssessment.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private HttpClient httpClient;
        public RequestProvider()
        {
            httpClient = CreateHttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "",
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage response = null;
            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                if (headers == null)
                {
                    headers = new Dictionary<string, string>();
                }

                SetHeaders(httpClient, headers);

                response = await httpClient.GetAsync(uri);

                string serialized = await response.Content.ReadAsStringAsync();
               
                TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));

                return result;

            }
            catch (Exception)
            {
                return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(""));
            }

        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data, string token = "", Dictionary<string, string> headers = null)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PutAsync<TResult, TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null)
        {
            throw new NotImplementedException();
        }

        public Task<string> PutAsync<TInput>(string uri, TInput data, string token = "", Dictionary<string, string> headers = null)
        {
            throw new NotImplementedException();
        }

        #region private methods
        private HttpClient CreateHttpClient(string token = "")
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(5);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return httpClient;
        }

        private void SetHeaders(HttpClient httpClient, Dictionary<string, string> headers)
        {
            httpClient.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
        #endregion
    }
}
