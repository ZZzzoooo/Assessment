using System.Threading.Tasks;
using Acr.UserDialogs;
using UndoAssessment.Service.Contract.Dialogs;

namespace UndoAssessment.Services.Dialogs
{
    public class UserDialogsService : IDialogsService
    {
        private readonly IUserDialogs _userDialogs;

        public UserDialogsService()
        {
            _userDialogs = UserDialogs.Instance;
        }
        
        public Task AlertAsync(string title, string message)
        {
            return _userDialogs.AlertAsync(message, title);
        }
    }
}