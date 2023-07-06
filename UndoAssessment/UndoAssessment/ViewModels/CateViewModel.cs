using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;

namespace UndoAssessment.ViewModels
{
    public class CateViewModel : BaseViewModel
    {
        
        #region Contructor

        public CateViewModel()
        {
            Title = "Assessment for Cate";

            PopupUserInfoCommand =  new Command(OnPopupUserInfoClicked);
            ApiSuccessCommand =     new Command(OnApiSuccessClicked);
            ApiFailCommand =        new Command(OnApiFailClicked);
        }

        #endregion

        #region Functions

        public void OnAppearing()
        {
            OnPropertyChanged(nameof(User));
            OnPropertyChanged(nameof(UserVisible));
        }

        public bool UserVisible
        {
            get
            {
                return user != null;
            }
        }

        #endregion

        #region Variables

        private UserModel user => DataStore.User;

        public String User
        {
            get
            {
                return user == null 
                    ? "" 
                    : $"Name: {user.Name}\n" + $"Age: {user.Age}";
            }
        }


        #endregion

        #region Commands

        public ICommand OpenWebCommand { get; }

        public Command PopupUserInfoCommand { get; }
        public Command ApiSuccessCommand { get; }
        public Command ApiFailCommand { get; }

        private readonly String successText = "Success API";
        private readonly String failureText = "Failure API";
        private readonly String cancelText  = "Cancel";

        private void OnPopupUserInfoClicked()
        {
            Shell.Current.GoToAsync(nameof(UserFormPage));
        }

        private async void AlertResult(ApiResponseModel resp)
        {
            if (resp.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(successText, resp.message, cancelText);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(failureText, resp.message, cancelText);
            }
        } 

        private async void OnApiSuccessClicked()
        {
            ApiResponseModel resp = await ApiService.GetSuccess();
            AlertResult(resp);
        }

        private async void OnApiFailClicked()
        {
            ApiResponseModel resp = await ApiService.GetFail();
            AlertResult(resp);
        }

        #endregion

    }
}
