using System.Threading.Tasks;

namespace UndoAssessment.Service.Contract.Dialogs
{
    public interface IDialogsService
    {
        Task AlertAsync(string title, string message);
    }
}