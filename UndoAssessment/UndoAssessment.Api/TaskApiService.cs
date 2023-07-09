using System.Net.Http;
using System.Threading.Tasks;
using UndoAssessment.Api.Extensions;
using UndoAssessment.Common.Models;

namespace UndoAssessment.Api
{
    public class TaskApiService : IApiService
    {
        private const string ApiEndpoint = "https://malkarakundostagingpublicapi.azurewebsites.net";
        
        private readonly HttpClient _client;

        public TaskApiService()
        {
            _client = new HttpClient();
        }
        
        public Task<ApiResponse> SuccessAsync()
            => _client
                .CreateRequest()
                .ByResource(ApiEndpoint, "/success")
                .WithMethod(HttpMethod.Get)
                .MakeRequestAsync()
                .ReadContentAsJsonAsync<ApiResponse>();
        
        public Task<ApiResponse> ErrorAsync()
            => _client
                .CreateRequest()
                .ByResource(ApiEndpoint, "/fail")
                .WithMethod(HttpMethod.Get)
                .MakeRequestAsync()
                .ReadContentAsJsonAsync<ApiResponse>();
    }
}