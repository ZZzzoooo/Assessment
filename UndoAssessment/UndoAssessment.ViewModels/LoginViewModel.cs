using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Common.Tools;

namespace UndoAssessment.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new AsyncCommand(OnLoginClicked);
        }

        private async Task OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            return Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

