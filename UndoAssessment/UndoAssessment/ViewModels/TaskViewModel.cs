using System;
using System.Diagnostics;
using UndoAssessment.Services.Api;
using UndoAssessment.Services.Dialogs;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private IApiService _apiService;
        private IDialogsService _dialogsService;
        
        public Command SuccessCommand { get; }
        public Command ErrorCommand { get; }

        public TaskViewModel()
        {
            SuccessCommand = new Command(OnSuccessCommand);
            ErrorCommand = new Command(OnErrorCommand);

            _apiService = DependencyService.Resolve<IApiService>();
            _dialogsService = DependencyService.Resolve<IDialogsService>();
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
    }
}