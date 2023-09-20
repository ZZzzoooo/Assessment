using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        public Command SuccessServiceCommand { get; }
        public Command ErrorServiceCommand { get; }
        public Command AddUserCommand { get; }
        public Command AddCommand { get; }

        private RequestService _service { get; set; }

        private string userName;
        private int age;

        public AssessmentViewModel()
        {
            SuccessServiceCommand = new Command(async () => await sendSuccessRequest());
            ErrorServiceCommand = new Command(async () => await sendErrorRequest());
            AddUserCommand = new Command(async () => await goToAddUser());
            AddCommand = new Command(async () => await addUser());
            _service = new RequestService();
        }

        private async Task sendSuccessRequest()
        {
            IsBusy = true;
            var model = await _service.SendRequest("https://malkarakundostagingpublicapi.azurewebsites.net/success");
            IsBusy = false;
            if (model == null)
            {
                Device.BeginInvokeOnMainThread(async () => {
                    await Shell.Current.DisplayAlert("Error", "System error occurred!", "Ok");
                });
            }

            await showSuccessMessage(model);
        }

        private async Task sendErrorRequest()
        {
            IsBusy = true;
            var model = await _service.SendRequest("https://malkarakundostagingpublicapi.azurewebsites.net/fail");
            IsBusy = false;
            if (model == null)
            {
                await Shell.Current.DisplayAlert("Error", "System error occurred!", "Ok");
            }

            await showErrorMessage(model);
        }

        private async Task goToAddUser()
        {
            await Shell.Current.GoToAsync($"//{nameof(UserPage)}");
        }

        private async Task showSuccessMessage(ResponseModel model)
        {
            await Shell.Current.DisplayAlert("Success", $"{model.Message} {model.Date}", "OK");
        }

        private async Task showErrorMessage(ResponseModel model)
        {
            await Shell.Current.DisplayAlert("Error", $"{model.ErrorCode} {model.Message} {model.Date}", "Ok");
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public int Age
        {
            get => age;
            set => SetProperty(ref age, value);
        }

        private async Task addUser()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}