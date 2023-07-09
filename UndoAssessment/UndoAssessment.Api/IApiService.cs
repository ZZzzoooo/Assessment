using System.Threading.Tasks;
using UndoAssessment.Common.Models;

namespace UndoAssessment.Api
{
    public interface IApiService
    {
        Task<ApiResponse> SuccessAsync();
        Task<ApiResponse> ErrorAsync();
    }
}