using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services.Interfaces
{
    public interface IApiService
    {
        Task<SuccessResponse> GetSuccess();
        Task<FailResponse> GetFail();
    }
}
