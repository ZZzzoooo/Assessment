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
        private String name;
        private String age;

        public UserFormViewModel()
        {
            SaveCommand = new Command(OnSaveClicked, ValidateSave);
            CancelCommand = new Command(OnCancelClicked);
            PropertyChanged += (_a, _b) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(age);
        }

        public String Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public String Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnSaveClicked()
        {
            DataStore.User = new UserModel {
                Name = Name,
                Age = Age
            };

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelClicked()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}

