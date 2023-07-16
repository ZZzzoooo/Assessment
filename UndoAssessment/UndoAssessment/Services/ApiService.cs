using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services.Base;

namespace UndoAssessment.Services
{
    public class ApiService : BaseApiService
    {
        public async Task<ApiResponseModel> InvokeSuccessEndpoint()
        {
            var response = await InvokeEndpoint("https://malkarakundostagingpublicapi.azurewebsites.net/success");
            return ExtractApiResponse(response);
        }

        public async Task<ApiResponseModel> InvokeFailEndpoint()
        {
            var response = await InvokeEndpoint("https://malkarakundostagingpublicapi.azurewebsites.net/fail");
            return ExtractApiResponse(response);
        }
    }
}
