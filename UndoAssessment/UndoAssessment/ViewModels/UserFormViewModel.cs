using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.ViewModels;
using UndoAssessment.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class UserFormViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }

        public ICommand SubmitCommand { get; }

        public UserFormViewModel()
        {
            SubmitCommand = CommandFactory.Create(SubmitAsync, onException: HandleException, allowsMultipleExecutions: false);
        }

        private async Task SubmitAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}?{nameof(UserName)}={UserName}&{nameof(UserAge)}={UserAge}");
        }
    }
}