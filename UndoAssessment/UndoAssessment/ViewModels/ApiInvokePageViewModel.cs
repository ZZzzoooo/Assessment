using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Essentials;
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

        private ApiService apiService;

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
                ApiResponse _response;

                if (IsInternetActive())
                {
                    // If the network is connected, then get the API response by calling the API
                    _response = await apiService.InvokeSuccessApi();
                }
                else
                {
                    // If the network is off, then retrieve the API response from the DB
                    _response = await apiService.GetStoredApiResponseAsync();
                }

                if (_response != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", _response.ApiInvokeSuccessMessage, "OK");
                }
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
                ApiResponse _response;

                if (IsInternetActive())
                {
                    // If the network is connected, then get the API response by calling the API
                    _response = await apiService.InvokeFailApi();
                }
                else
                {
                    // If the network is off, then retrieve the API response from the DB
                    _response = await apiService.GetStoredApiResponseAsync();
                }

                if (_response != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", _response.ApiInvokeFailureMessage, "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // This is for furture implementation when need to see the stored variables.
        private async Task<ApiResponse> LoadStoredApiResponseAsync()
        {
            return await apiService.GetStoredApiResponseAsync();
        }

        private async void ShowUserInfoForm()
        {
            // Implement navigation to the user info form page
            await Shell.Current.GoToAsync(nameof(UserInfoFormPage));
        }

        private bool IsInternetActive()
        {
            // We have this own function to expand its functionality in the furture
            return Connectivity.NetworkAccess == NetworkAccess.Internet;
        }
    }
}

