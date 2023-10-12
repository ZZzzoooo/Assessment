using System;
using System.Collections.Generic;
using System.Web;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
	public class ApiCallViewModel : BaseViewModel, IQueryAttributable
    {
		private readonly ITempApiService _tempApiService;
        private readonly IPopupService _popupService;

        public ApiCallViewModel()
		{
            _tempApiService = DependencyService.Resolve<ITempApiService>();
            _popupService = DependencyService.Resolve<IPopupService>();
            SuccessApiCallCommand = new Command(OnSuccessApiCall);
            FailApiCallCommand = new Command(OnFailApiCall);
            GetUserInfoCommand = new Command(OnGetUserInfo);
        }

        public Command SuccessApiCallCommand { get; }

        public Command FailApiCallCommand { get; }

        public Command GetUserInfoCommand { get; }

        private async void OnSuccessApiCall(object obj)
        {
            var response = await _tempApiService.SuccessApiCall();
            if(response != null)
            {
               await _popupService.ShowMessageAsync(response.Message ?? "");
            }
        }

        private async void OnFailApiCall(object obj)
        {
            var response = await _tempApiService.FailApiCall();
            if (response != null)
            {
                await _popupService.ShowMessageAsync(response.Message ?? "");
            }
        }

        private async void OnGetUserInfo(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(UserInfoPage)}");

        }

        public async void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            string name = HttpUtility.UrlDecode(query["name"]);
            string age = HttpUtility.UrlDecode(query["age"]);

            string message = "";
            if (!string.IsNullOrWhiteSpace(name))
            {
                message += $"Name: {name}  ";
            }
            if (!string.IsNullOrWhiteSpace(age))
            {
                message += $"Age: {age}";
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                await _popupService.ShowMessageAsync(message);
            }
        }
    }
}

