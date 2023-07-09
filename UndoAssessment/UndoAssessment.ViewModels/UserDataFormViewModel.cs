using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.UserData)]
    public class UserDataFormViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        
        public string Name { get; set; }
        public int Age { get; set; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public UserDataFormViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveCommand = new AsyncCommand(OnSaveCommand);
            CancelCommand = new AsyncCommand(OnCancelCommand);
        }

        private Task OnCancelCommand()
        {
            return _navigationService.NavigateBackAsync();
        }

        private async Task OnSaveCommand()
        {
            var u = new UserData
            {
                Name = Name,
                Age = Age
            };
            
            await _navigationService.NavigateBackAsync(
                new KeyValuePair<string, object>("UserData", u));
        }
    }
}