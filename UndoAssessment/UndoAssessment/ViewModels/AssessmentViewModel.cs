using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Models;
using UndoAssessment.Popups;
using UndoAssessment.Services;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        string userName = string.Empty;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }
        bool isUserNameVisible = false;
        public bool IsUserNameVisible
        {
            get { return isUserNameVisible; }
            set { SetProperty(ref isUserNameVisible, value); }
        }
        string age = string.Empty;
        public string Age
        {
            get { return age; }
            set { SetProperty(ref age, value); }
        }
        bool isAgeVisible = false;
        public bool IsAgeVisible
        {
            get { return isAgeVisible; }
            set { SetProperty(ref isAgeVisible, value); }
        }
        public Command ExecuteSuccessCommand { get; }
        public Command ExecuteFailCommand { get; }
        public Command SubmitCommand { get; }

        private readonly ApiService _apiService;
        private readonly IPopupService _popupService;
        public AssessmentViewModel()
        {
            Title = "Assessment";
            _apiService = new ApiService();
            _popupService = DependencyService.Get<IPopupService>();

            SubmitCommand = new Command( () =>  ExecuteSubmit());
            ExecuteSuccessCommand = new Command(async () => await ExecuteRequestAsync("https://malkarakundostagingpublicapi.azurewebsites.net/success"));
            ExecuteFailCommand = new Command(async () => await ExecuteRequestAsync("https://malkarakundostagingpublicapi.azurewebsites.net/fail"));
        }
        private async Task ExecuteRequestAsync(string apiUrl)
        {
            IsBusy = true;
            ResponseModel result = await _apiService.ExecuteRequestAsync(apiUrl);
            IsBusy = false;
            if (result != null)
            {
                if (result.isSuccess)
                {
                    _popupService.ShowResultPopup(result.isSuccess, result.message);
                }
                else
                {
                    _popupService.ShowResultPopup(result.isSuccess, result.message);
                }
            }
            else
            {
                _popupService.ShowResultPopup(false, "There is an unknown issue, please try it later");
            }
        }

        private void  ExecuteSubmit()
        {
            _popupService.SubmitPopup(ShowUserData);
        }

        public ICommand ShowUserData => new Command(async (o) =>
        {
            if (o is object[] objArray)
            {
                if (objArray.Length >= 2)
                {
                    UserName = objArray[0] as string;
                    Age = objArray[1] as string;

                    IsAgeVisible = IsUserNameVisible = true;
                }
            }
        });

    }
}
