using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace UndoAssessment.Extensions
{
    public static class HttpExtensions
    {
        public static HttpRequestBuilder CreateRequest(this HttpClient client)
            => new HttpRequestBuilder(client);

        public static HttpContent ToHttpContent(this object requestBody)
        {
            var result = default(HttpContent);
            
            if (requestBody is HttpContent content)
            {
                result = content;
            }
            else
            {
                var jsonString = JsonConvert.SerializeObject(requestBody ?? new object(), new IsoDateTimeConverter());
                result = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }

            return result;
        }
    }
}