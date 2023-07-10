using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string title, string message, string cancel);
    }
}
