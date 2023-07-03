using System;
using System.Numerics;
using UndoAssessment.Models;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class UserInfoFormViewModel : BaseViewModel
    {
        private string userName;
        private string userAge;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string UserAge
        {
            get => userAge;
            set => SetProperty(ref userAge, value);
        }

        public Command SubmitUserInfoCommand { get; }
        public UserInfoFormViewModel()
        {
            SubmitUserInfoCommand = new Command(SubmitUserInfo);
        }

        async private void SubmitUserInfo()
        {
            // Validate the user information
            if (string.IsNullOrEmpty(userName) || int.Parse(userAge) <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter valid information", "OK");
            }
            else
            {
                // Create UserInfoText to pass back to the previous page
                string userInfoText = $"Name: {userName}, Age: {userAge}";
                // Navigate back to the previous page with UserInfoText as a navigation parameter
                await Shell.Current.GoToAsync($"..?{nameof(ApiInvokePageViewModel.UserInfoText)}={userInfoText}");
            }
        }
    }
}