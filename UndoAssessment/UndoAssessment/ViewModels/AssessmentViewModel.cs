using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        private readonly IAssessmentService _assessmentService;

        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _userName;

        public string Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        private string _age;

        public Command SuccessCommand { get; }
        public Command FailureCommand { get; }
        public Command AddUserInfoCommand { get; }

        public AssessmentViewModel()
        {
            _assessmentService = DependencyService.Get<IAssessmentService>();
            SuccessCommand = new Command(OnSuccessTapped);
            FailureCommand = new Command(OnFailureTapped);
            AddUserInfoCommand = new Command(OnAddUserInfoTapped);
        }
        public void LoadUserData()
        {
            UserName = Preferences.Get(nameof(UserName), "");
            Age = Preferences.Get(nameof(Age), "");
        }

        #region Commands
        private async void OnAddUserInfoTapped(object obj)
        {
            await Shell.Current.GoToAsync("AddUserInfoPage");
        }
        private async void OnSuccessTapped(object obj)
        {
            try
            {
                var response = await _assessmentService.ExecuteSuccessAPI();
                if (response != null)
                {
                    await DisplayAlertMessage(response.Message);
                }
                else
                {
                    await DisplayAlertMessage("No Response");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlertMessage(ex.Message);
            }
        }
        private async void OnFailureTapped(object obj)
        {
            try
            {
                var response = await _assessmentService.ExecuteFailureAPI();
                if (response != null)
                {
                    await DisplayAlertMessage(response.Message);
                }
                else
                {
                    await DisplayAlertMessage("No Response");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlertMessage(ex.Message);
            }
        }
        #endregion

        private async Task DisplayAlertMessage(string message)
        {
            await App.Current.MainPage.DisplayAlert("Assessment", message, "Ok");
        }
    }
}
