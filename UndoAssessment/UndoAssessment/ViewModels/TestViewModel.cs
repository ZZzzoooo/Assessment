using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;

namespace UndoAssessment.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        #region Variables

        private TestService _testService = new TestService();

        private UserModel _user => DataStore.GetUser();

        public string User
        {
            get
            {
                if (_user == null)
                    return "";
                else
                    return $"Name: {_user.Name}\n" +
                           $"Age: {_user.Age}";
            }
        }

        public bool UserVisibility
        {
            get
            {
                return _user != null;
            }
        }

        #endregion

        #region Commands

        public Command GotoUserFormCommand { get; }

        public Command Api1Command { get; }
        public Command Api2Command { get; }

        private void OnGotoUserFormClicked()
        {
            Shell.Current.GoToAsync(nameof(UserFormPage));
        }

        private async void OnApi1Clicked()
        {
            var response = await _testService.GetSuccess();

            if (response.IsSuccess)
                await Application.Current.MainPage.DisplayAlert("Success", response.message, "Close");
            else
                await Application.Current.MainPage.DisplayAlert("Failure", response.message, "Close");
        }

        private async void OnApi2Clicked()
        {
            var response = await _testService.GetFailure();

            if (response.IsSuccess)
                await Application.Current.MainPage.DisplayAlert("Success", response.message, "Close");
            else
                await Application.Current.MainPage.DisplayAlert("Failure", response.message, "Close");
        }

        #endregion

        #region Contructor

        public TestViewModel()
        {
            Title = "Test Page";

            GotoUserFormCommand = new Command(OnGotoUserFormClicked);
            Api1Command = new Command(OnApi1Clicked);
            Api2Command = new Command(OnApi2Clicked);
        }

        #endregion

        #region Member functions

        public void OnAppearing()
        {
            OnPropertyChanged(nameof(User));
            OnPropertyChanged(nameof(UserVisibility));
        }

        #endregion
    }
}