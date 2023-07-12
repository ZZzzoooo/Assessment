using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public class ApiService : IApiService
    {
        public async Task<string> GetContent(string uri)
        {
            var client = new HttpClient();

            using (var response = await client.GetAsync(uri))
            {
                if (response?.StatusCode == System.Net.HttpStatusCode.OK
                    || response?.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                    throw new Exception("Unexpected request status code");
            }
        }

    }
}
