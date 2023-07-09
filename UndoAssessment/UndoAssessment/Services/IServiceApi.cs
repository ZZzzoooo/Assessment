using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Services
{
	public interface IServiceApi
	{
        Task<SuccessfulResponse> RequestSuccess();
        Task<FailureResponse> RequestFailure();
    }
}