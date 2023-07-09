using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UndoAssessment.Extensions
{
    public class HttpRequestBuilder
    {
        private readonly HttpClient _client;

        private HttpRequestMessage _buildingRequest;
        private CancellationToken _cancellationToken;

        public HttpRequestBuilder(HttpClient client)
        {
            _client = client;

            _buildingRequest = new HttpRequestMessage();
        }

        public HttpRequestBuilder ByResource(string address, string resource, params object[] parameters)
        {
            var url = address + string.Format(resource, parameters);
            _buildingRequest.RequestUri = new Uri(url);
            return this;
        }

        public HttpRequestBuilder WithMethod(HttpMethod method)
        {
            _buildingRequest.Method = method;
            return this;
        }

        public HttpRequestBuilder WithContent(object content)
        {
            _buildingRequest.Content = content.ToHttpContent();
            return this;
        }

        public HttpRequestBuilder WithHeader(string type, string val)
        {
            _buildingRequest.Headers.Add(type, val);
            return this;
        }

        public async Task<HttpResponseMessage> MakeRequestAsync()
        {
            try
            {
                return await _client.SendAsync(_buildingRequest, _cancellationToken);
            }
            catch (Exception e)
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                Console.WriteLine(e);
                throw;
            }
        }
    }
}