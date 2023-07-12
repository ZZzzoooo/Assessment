using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public interface IMessageService
    {
        Task ShowMessage(string message);
    }
}
