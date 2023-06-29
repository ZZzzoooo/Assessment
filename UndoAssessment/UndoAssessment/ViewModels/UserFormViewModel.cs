using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class UserFormViewModel : BaseViewModel
    {
        private string name;
        private string age;

        public UserFormViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += 
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(age);
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
            DataStore.SetUser(new UserModel
            {
               Name = Name,
               Age = Age
            });

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}

