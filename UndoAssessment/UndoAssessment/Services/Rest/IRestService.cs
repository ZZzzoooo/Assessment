using System.Threading;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Models.Data;

namespace UndoAssessment.Services.Rest
{
    public interface IRestService
    {
        Task<ApiResult<SuccessModel>> TestSuccess(CancellationToken cancellationToken);
        Task<ApiResult<FailureModel>> TestFailure(CancellationToken cancellationToken);
    }
}
