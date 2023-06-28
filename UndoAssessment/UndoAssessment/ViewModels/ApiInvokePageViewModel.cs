using System;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    [QueryProperty(nameof(UserInfoText), nameof(UserInfoText))]
    public class ApiInvokePageViewModel : BaseViewModel
    {
        public Command SuccessApiCommand { get; }
        public Command FailApiCommand { get; }
        public Command ShowUserInfoFormCommand { get; }

        public string userInfoText;

        private readonly ApiService apiService;

        public string UserInfoText
        {
            get
            {
                return userInfoText;
            }
            set 
            {
                SetProperty(ref userInfoText, value);
            }
        }

        public ApiInvokePageViewModel()
        {
            Title = "API & USER";
            apiService = new ApiService();
            SuccessApiCommand = new Command(async () => await InvokeSuccessApi());
            FailApiCommand = new Command(async () => await InvokeFailApi());
            ShowUserInfoFormCommand = new Command(ShowUserInfoForm);            
        }

        private async Task InvokeSuccessApi()
        {
            try
            {
                string response = await apiService.InvokeSuccessApi();
                await Application.Current.MainPage.DisplayAlert("Success", response, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task InvokeFailApi()
        {
            try
            {
                string response = await apiService.InvokeFailApi();
                await Application.Current.MainPage.DisplayAlert("Error", response, "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void ShowUserInfoForm()
        {
            // Implement navigation to the user info form page
            await Shell.Current.GoToAsync(nameof(UserInfoFormPage));
        }
    }
}

