using System.Threading.Tasks;
using UndoAssessment.Api.Models;

namespace UndoAssessment.Api
{
    public interface IApiService
    {
        Task<ApiResponse> SuccessAsync();
        Task<ApiResponse> ErrorAsync();
    }
}