using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public interface IApiService
    {
        Task<string> GetContent(string uri);
    }
}
