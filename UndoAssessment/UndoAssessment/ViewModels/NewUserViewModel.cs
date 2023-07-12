using System;
using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class NewUserViewModel : BaseViewModel<User>
    {
        private string name;
        private string age;

        public NewUserViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += 
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && byte.TryParse(age, out byte tempAge)
                && tempAge >= 0;
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            User newUser = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Age = byte.Parse(Age)
            };
            
            await DataStore.AddItemAsync(newUser);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

