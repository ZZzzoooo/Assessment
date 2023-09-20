using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
    public class RequestService
    {
        public RequestService() { }

        public async Task<ResponseModel> SendRequest(string url)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url);
            var stringResult = await result.Content.ReadAsStringAsync();
            var jsonResult = JsonConvert.DeserializeObject<ResponseModel>(stringResult);
            return jsonResult;
        }
    }
}
