using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Services.Interfaces;
using UndoAssessment.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        public ICommand SuccessCommand { get; }
        public ICommand FailCommand { get; }
        public ICommand UserFormCommand { get; }
        public IAssessmentService _assesmentService => DependencyService.Get<IAssessmentService>();

        private string _userInfo;

        public string UserInfo
        {
            get => _userInfo;
            set
            {
                _userInfo = value;
                OnPropertyChanged();
            }
        }

        public AssessmentViewModel()
        {
            Title = "Assessment";
            SuccessCommand = new AsyncCommand(async () => await CallSucc(), allowsMultipleExecutions: false);
            FailCommand = new AsyncCommand(async () => await CallFail(), allowsMultipleExecutions: false);
            UserFormCommand = new AsyncCommand(async () => await OpenUserForm(), allowsMultipleExecutions: false);

            MessagingCenter.Subscribe<UserInfoPage, User>(this, "UserDataEntered", (sender, user) =>
            {
                UserInfo = $"Name: {user.Name}, Age: {user.Age}";
            });
        }


        public async Task CallSucc()
        {
            var response = await _assesmentService.CallApi<SuccessResult>("success");
            await App.Current.MainPage.DisplayAlert("Message", response.IsSuccess ? response.Data.Message : response.ErrorMessage, "Ok");
        }

        public async Task CallFail()
        {
            var response = await _assesmentService.CallApi<SuccessResult>("fail");
            await App.Current.MainPage.DisplayAlert("Message", response.IsSuccess ? response.Data.Message : response.ErrorMessage, "Ok");
        }

        public async Task OpenUserForm()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UserInfoPage());
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<UserInfoPage, User>(this, "UserDataEntered");
        }
    }
}
