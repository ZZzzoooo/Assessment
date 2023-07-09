using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class UserDataFormViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public UserDataFormViewModel()
        {
            SaveCommand = new Command(OnSaveCommand);
            CancelCommand = new Command(OnCancelCommand);
        }

        private async void OnCancelCommand()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSaveCommand()
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