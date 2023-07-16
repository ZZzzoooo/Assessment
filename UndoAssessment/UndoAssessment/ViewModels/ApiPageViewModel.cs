using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UndoAssessment.Helpers;
using UndoAssessment.Models;
using UndoAssessment.Services;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class ApiPageViewModel : INotifyPropertyChanged
    {
        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private bool _isUserInformationVisible;
        public bool IsUserInformationVisible
        {
            get { return _isUserInformationVisible; }
            set
            {
                _isUserInformationVisible = value;
                OnPropertyChanged(nameof(IsUserInformationVisible));
            }
        }

        private readonly ApiService _apiService;

        public ApiPageViewModel()
        {
            _apiService = new ApiService();
            User = new UserModel(); 
            IsUserInformationVisible = false;
        }


        public async Task InvokeSuccessEndpoint()
        {
            try
            {
                var response = await _apiService.InvokeSuccessEndpoint();
                await ApiRequestHandler.DisplaySuccessMessage(response);
            }
            catch (ApiRequestException ex)
            {
                await ApiRequestHandler.HandleApiRequestException(ex);
            }
        }

        public async Task InvokeFailEndpoint()
        {
            try
            {
                var response = await _apiService.InvokeFailEndpoint();
                await ApiRequestHandler.DisplayErrorMessage(response);
            }
            catch (ApiRequestException ex)
            {
                await ApiRequestHandler.HandleApiRequestException(ex);
            }
        }




        public async Task AddUserInformation()
        {
            var name = await Application.Current.MainPage.DisplayPromptAsync("User Information", "Enter your name");
            var age = await Application.Current.MainPage.DisplayPromptAsync("User Information", "Enter your age");

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(age))
            {
                // Validate age
                if (!ValidationHelper.IsAgeValid(age))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid age. Please enter a numeric value for age.", "OK");
                    return;
                }

                // Validate name
                if (!ValidationHelper.IsNameValid(name))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid name. Please enter a valid name.", "OK");
                    return;
                }

                User.Name = name;
                User.Age = age;
                IsUserInformationVisible = true;

                OnPropertyChanged(nameof(User));
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
