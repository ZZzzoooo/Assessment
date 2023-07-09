using System.Threading.Tasks;

namespace UndoAssessment.Services.Dialogs
{
    public interface IDialogsService
    {
        Task AlertAsync(string message);
    }
}