using System.Threading.Tasks;
using Acr.UserDialogs;

namespace UndoAssessment.Services.Dialogs
{
    public class UserDialogsService : IDialogsService
    {
        private readonly IUserDialogs _userDialogs;

        public UserDialogsService()
        {
            _userDialogs = UserDialogs.Instance;
        }
        
        public Task AlertAsync(string message)
        {
            return _userDialogs.AlertAsync(message, "Api Call");
        }
    }
}