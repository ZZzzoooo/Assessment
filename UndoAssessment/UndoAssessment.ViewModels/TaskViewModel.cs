using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Api;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Tools;
using UndoAssessment.Service.Contract.Dialogs;

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
        public ICommand UpdateUserDataCommand { get; }
        public ICommand SuccessCommand { get; }
        public ICommand ErrorCommand { get; }

        public TaskViewModel()
        {
            SuccessCommand = new AsyncCommand(OnSuccessCommand);
            ErrorCommand = new AsyncCommand(OnErrorCommand);
            UpdateUserDataCommand = new AsyncCommand(OnUpdateUserDataCommand);
            
            IsUserDataCreated = false;
            User = UserData;

            _apiService = DependencyService.Resolve<IApiService>();
            _dialogsService = DependencyService.Resolve<IDialogsService>();
        }

        private async Task OnSuccessCommand()
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

        private async Task OnErrorCommand()
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

        private async Task OnUpdateUserDataCommand()
        {
            return Shell.Current.GoToAsync(nameof(UserDataFormPage));
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