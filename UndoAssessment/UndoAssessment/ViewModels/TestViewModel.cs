using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Models;
using UndoAssessment.Services.Dialog;
using UndoAssessment.Services.Rest;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        private readonly IRestService _restService;
        private readonly IDialogsService _dialogService;
        //TODO: Move profile to local storage
        private ProfileModel _profileModel;
        public TestViewModel()
        {
             _restService = DependencyService.Get<IRestService>();
            _dialogService = DependencyService.Get<IDialogsService>();
            Title = "Test";
            CallSuccessCommand = new Command(async () => await CallSuccessCommandHandler());
            CallFailCommand = new Command(async () => await CallFailCommandHandler());
            OpenProfileCommand = new Command(async () => await OpenProfileCommandHandler());
        }

        public ICommand CallSuccessCommand { get; }
        public ICommand CallFailCommand { get; }
        public ICommand OpenProfileCommand { get; }
        public bool AgeVisible => Age != null;
        public bool NameVisible => Name != null;

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _age = string.Empty;
        public string Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }


        private async Task CallFailCommandHandler()
        {
            //TODO: Implement loading overlay to display that the request is going
            var result =  await _restService.TestFailure(CancellationToken.None);
            await _dialogService.ShowAlertAsync(result.Result);
        }

        private async Task CallSuccessCommandHandler()
        {
            //TODO: Implement loading overlay to display that the request is going
            var result = await _restService.TestSuccess(CancellationToken.None);
            await _dialogService.ShowAlertAsync(result.Result);
        }

        private async Task OpenProfileCommandHandler()
        {
            var profile = await _dialogService.ShowProfileDialogAsync(_profileModel).ConfigureAwait(false);
            _profileModel = profile;
            if (profile != null)
            {
                Age = $"Age: {profile.Age}";
                Name = $"Name: {profile.Name}";
            }
            else
            {
                Age = null;
                Name = null;
            }
            OnPropertyChanged(nameof(AgeVisible));
            OnPropertyChanged(nameof(NameVisible));
        }
    }
}
