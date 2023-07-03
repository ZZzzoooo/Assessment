using System;
using UndoAssessment;
using UndoAssessment.ViewModels;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace Assesment1.ViewModels
{
    public class NewUserViewModel : BaseViewModel
    {
        public Command SubmitCommand { get; }
        public Command CancelCommand { get; }
        public NewUserViewModel()
        {
            Title = "New User";
            SubmitCommand = new Command(SubmitCmd);
            CancelCommand = new Command(CancelCmd);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(UserName)
                && !String.IsNullOrWhiteSpace(UserAge);
        }

        private async void SubmitCmd()
        {
            if (ValidateSave() == false)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Pelase fill all required field", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(AssesmentResultPage)}?{nameof(AssesmentResultViewModel.User)}={UserName + " - " + UserAge }");
        }

        private async void CancelCmd()
        {
            await Shell.Current.GoToAsync("//AssesmentPage");
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string userAge;
        public string UserAge
        {
            get => userAge;
            set => SetProperty(ref userAge, value);
        }
    }
}
