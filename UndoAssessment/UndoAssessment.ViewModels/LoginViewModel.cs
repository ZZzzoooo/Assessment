using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain.Navigation;

namespace UndoAssessment.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        
        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LoginCommand = new AsyncCommand(OnLoginClicked);
        }

        private Task OnLoginClicked(object obj)
        {
            return _navigationService.NavigateBackAsync();
        }
    }
}

