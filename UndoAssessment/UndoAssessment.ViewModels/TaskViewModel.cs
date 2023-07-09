using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Api;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain;
using UndoAssessment.Domain.Navigation.Attributes;
using UndoAssessment.Service.Contract.Dialogs;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.TaskPage)]
    public class TaskViewModel : BaseViewModel, INavigated
    {
        private readonly IApiService _apiService;
        private readonly IDialogsService _dialogsService;
        private readonly INavigationService _navigationService;
        
        public bool IsUserDataCreated { get; set; }
        public UserData User { get; set; }
        public ICommand UpdateUserDataCommand { get; }
        public ICommand SuccessCommand { get; }
        public ICommand ErrorCommand { get; }

        public TaskViewModel(IApiService apiService, IDialogsService dialogsService, INavigationService navigationService)
        {
            _apiService = apiService;
            _dialogsService = dialogsService;
            _navigationService = navigationService;

            SuccessCommand = new AsyncCommand(OnSuccessCommand);
            ErrorCommand = new AsyncCommand(OnErrorCommand);
            UpdateUserDataCommand = new AsyncCommand(OnUpdateUserDataCommand);
            
            IsUserDataCreated = false;
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

        private Task OnUpdateUserDataCommand()
        {
            return _navigationService.NavigateAsync(NavigationTags.UserData);
        }

        public Task NavigatedAsync(NavigationData data)
        {
            if (data.Parameters.ContainsKey("UserData"))
                User = data.Parameters["UserData"] as UserData;
            IsUserDataCreated = User != null;
            OnPropertyChanged(nameof(IsUserDataCreated));
            OnPropertyChanged(nameof(User));
            return Task.CompletedTask;
        }
    }
}