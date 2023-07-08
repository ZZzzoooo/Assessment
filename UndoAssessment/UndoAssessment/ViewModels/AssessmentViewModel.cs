using Acr.UserDialogs;
using AsyncAwaitBestPractices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        private bool _isUserFormVisible = false;
        private string _userName;
        private string _userAge;

        public bool IsUserFormVisible
        {
            get => _isUserFormVisible;
            set => SetProperty(ref _isUserFormVisible, value);
        }
        
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        public string UserAge
        {
            get => _userAge;
            set => SetProperty(ref _userAge, value);
        }       

        public ICommand SuccessCommand { get; }
        public ICommand FailCommand { get; }
        public ICommand OpenFormCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CloseFormCommand { get; }
        

        public AssessmentViewModel()
        {
            SuccessCommand = new Command(async () => await HandleSuccess());
            FailCommand = new Command(async () => await HandleFail());
            OpenFormCommand = new Command(() => IsUserFormVisible = true);
            SubmitCommand = new Command(HandleSubmit);
            CloseFormCommand = new Command(() => IsUserFormVisible = false);
        }

        private async Task HandleSuccess()
        {
            var res = await TryDataProcessing(ApiService.GetSuccess, false);
            UserDialogs.Instance.AlertAsync(res?.Message ?? "Unable to get success response").SafeFireAndForget();
        }

        private async Task HandleFail()
        {
            var res = await TryDataProcessing(ApiService.GetFail, false);
            UserDialogs.Instance.AlertAsync(res?.Message ?? "Unable to get fail response").SafeFireAndForget();
        }

        private void HandleSubmit()
        {
            IsUserFormVisible = false;
        }
    }
}
