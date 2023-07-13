using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Rest
{
    public class BaseRestService
    {
        public BaseRestService()
        {
            BaseUrl = "https://malkarakundostagingpublicapi.azurewebsites.net/";
        }

        public string BaseUrl { get; private set; }


        protected async Task<ServerResponseModel<T>> GetAsync<T>(string resource, CancellationToken cancellationToken, Dictionary<string, string> additionalHeaders = null)
        {
            var client = CreateHttpClient(DefaultHeaders(additionalHeaders));
            var url = GetRequestUrl(BaseUrl, resource);
            var response = client.GetAsync(url, cancellationToken).GetAwaiter().GetResult();

            var data = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(data);
            return new ServerResponseModel<T>(response.IsSuccessStatusCode, model);
        }

        internal string BuildParametersString(Dictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
                return string.Empty;

            var sb = new StringBuilder("?");
            var needAddDivider = false;

            foreach (var item in parameters)
            {
                if (needAddDivider)
                    sb.Append('&');
                var encodedKey = WebUtility.UrlEncode(item.Key);
                var encodedVal = WebUtility.UrlEncode(item.Value);
                sb.Append($"{encodedKey}={encodedVal}");

                needAddDivider = true;
            }

            return sb.ToString();
        }

        private string GetRequestUrl(string host, string resource, Dictionary<string, string> parameters = null)
        {
            var paramsStr = BuildParametersString(parameters);
            return $"{host}{resource}{paramsStr}";
        }

        private Dictionary<string, string> DefaultHeaders(Dictionary<string, string> additionalHeaders = null)
        {
            var defHeaders = new Dictionary<string, string>
            {
                ["User-Agent"] = "Mobile",
                ["Accept"] = "application/json",
            };

            if (additionalHeaders != null)
                foreach (var kv in additionalHeaders)
                {
                    defHeaders.Add(kv.Key, kv.Value);
                }
            return defHeaders;
        }

        private HttpClient CreateHttpClient(Dictionary<string, string> headerParams = null)
        {
            var httpClient = new HttpClient();

            if (headerParams != null)
                foreach (var headerParam in headerParams)
                    httpClient.DefaultRequestHeaders.Add(headerParam.Key, headerParam.Value);

            return httpClient;
        }
    }
}
