using System;
using System.Diagnostics;
using UndoAssessment.Services.Api;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private IApiService _apiService;
        
        public Command SuccessCommand { get; }
        public Command ErrorCommand { get; }

        public TaskViewModel()
        {
            SuccessCommand = new Command(OnSuccessCommand);
            ErrorCommand = new Command(OnErrorCommand);

            _apiService = DependencyService.Resolve<IApiService>();
        }

        private async void OnErrorCommand()
        {
            try
            {
                var response = await _apiService.ErrorAsync();
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