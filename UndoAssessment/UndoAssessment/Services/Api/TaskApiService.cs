using System.Net.Http;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Api
{
    public class TaskApiService : IApiService
    {
        private readonly HttpClient _client;

        public TaskApiService(HttpClient client)
        {
            _client = client;
        }
        
        public Task<ApiResponse> SuccessAsync()
        {
            
        }

        public Task<ApiResponse> ErrorAsync()
        {
            
        }
    }
}