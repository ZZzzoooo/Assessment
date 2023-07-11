using System;
using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class NewUserViewModel : BaseViewModel
    {
        public Command SubmitCommand { get; }

        public Command CancelCommand { get; }

        public NewUserViewModel()
        {
            SubmitCommand = new Command(OnSubmit, ValidateSubmit);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SubmitCommand.ChangeCanExecute();
        }

        private bool ValidateSubmit()
        {
            return !String.IsNullOrWhiteSpace(_name)
                && !String.IsNullOrWhiteSpace(_age);
        }

        private async void OnSubmit()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Age = uint.Parse(Age)
            };

            await UserDataStore.AddItemAsync(newUser);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _age = null;
        public string Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
    }
}
