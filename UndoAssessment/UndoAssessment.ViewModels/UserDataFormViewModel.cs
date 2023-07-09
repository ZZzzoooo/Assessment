using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Tools;

namespace UndoAssessment.ViewModels
{
    public class UserDataFormViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public UserDataFormViewModel()
        {
            SaveCommand = new AsyncCommand(OnSaveCommand);
            CancelCommand = new AsyncCommand(OnCancelCommand);
        }

        private async Task OnCancelCommand()
        {
            return Shell.Current.GoToAsync("..");
        }

        private async Task OnSaveCommand()
        {
            TaskViewModel.UserData = new UserData
            {
                Name = Name,
                Age = Age
            };
            
            await Shell.Current.GoToAsync("..");
        }
    }
}