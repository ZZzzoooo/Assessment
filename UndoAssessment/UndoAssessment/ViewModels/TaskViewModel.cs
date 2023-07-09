using System;
using System.Diagnostics;
using UndoAssessment.Api;
using UndoAssessment.Models;
using UndoAssessment.Services.Dialogs;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        //This is awful, but without normal navigation service hardly to get back some results
        public static UserData UserData;
        
        private IApiService _apiService;
        private IDialogsService _dialogsService;
        
        public bool IsUserDataCreated { get; set; }
        public UserData User { get; set; }
        public Command UpdateUserDataCommand { get; }
        public Command SuccessCommand { get; }
        public Command ErrorCommand { get; }

        public TaskViewModel()
        {
            SuccessCommand = new Command(OnSuccessCommand);
            ErrorCommand = new Command(OnErrorCommand);
            UpdateUserDataCommand = new Command(OnUpdateUserDataCommand);
            
            IsUserDataCreated = false;
            User = UserData;

            _apiService = DependencyService.Resolve<IApiService>();
            _dialogsService = DependencyService.Resolve<IDialogsService>();
        }

        private async void OnSuccessCommand()
        {
            try
            {
                var response = await _apiService.SuccessAsync();
                await _dialogsService.AlertAsync(response.Message, response.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (Debugger.IsAttached)
                    Debugger.Break();
            }
        }

        private async void OnErrorCommand()
        {
            try
            {
                var response = await _apiService.ErrorAsync();
                await _dialogsService.AlertAsync(response.Message, response.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (Debugger.IsAttached)
                    Debugger.Break();
            }
        }

        private async void OnUpdateUserDataCommand()
        {
            await Shell.Current.GoToAsync(nameof(UserDataFormPage));
        }

        public void OnAppearing()
        {
            User = UserData;
            IsUserDataCreated = User != null;
            OnPropertyChanged(nameof(IsUserDataCreated));
            OnPropertyChanged(nameof(User));
        }
    }
}