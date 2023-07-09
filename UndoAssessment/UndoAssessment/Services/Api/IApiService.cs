using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Api
{
    public interface IApiService
    {
        Task<ApiResponse> SuccessAsync();
        Task<ApiResponse> ErrorAsync();
    }
}