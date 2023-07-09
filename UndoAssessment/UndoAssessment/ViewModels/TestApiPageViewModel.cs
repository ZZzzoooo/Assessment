using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    [QueryProperty(nameof(UserName), "name")]
    [QueryProperty(nameof(Age), "age")]
    public class TestApiPageViewModel:BaseViewModel, IQueryAttributable
    {
        #region Command
        public ICommand SuccessfulCommand { get; }
        public ICommand FailureCommand { get; }
        public ICommand UserInfoCommand { get; }
        #endregion

        #region UserInfo
        private string userName;
        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        private string age;
        public string Age { get => age; set => SetProperty(ref age, value); }      
        private bool isUserInfoVisible;
        public bool IsUserInfoVisible { get => isUserInfoVisible; set => SetProperty(ref isUserInfoVisible, value); }        
        #endregion

        public TestApiPageViewModel()
		{
            SuccessfulCommand = new Command(async () => await CallSuccessfulApi());
            FailureCommand = new Command(async () => await CallFailureApi());
            UserInfoCommand = new Command(async () => await OpenUserInfoForm());
            IsUserInfoVisible = false;
        }

        #region ApiCall
        private async Task CallSuccessfulApi()
        {
            var res =await PreProcessing(ServiceApi.RequestSuccess,false);
            await UserDialogs.Instance.AlertAsync(res?.message ?? "There's an error retrieve data for Success Api");
        }

        private async Task CallFailureApi()
        {
            var res = await PreProcessing(ServiceApi.RequestFailure, false);
            await UserDialogs.Instance.AlertAsync(res?.message ?? "There's an error retrieve data for Fail Api");
        }
        #endregion

        #region navigate to
        private async Task OpenUserInfoForm()
        {
            await Shell.Current.GoToAsync("UserInfoPage");
        }
        #endregion

        #region QueryAttributes
        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            UserName = HttpUtility.UrlDecode(query["name"]);
            Age = HttpUtility.UrlDecode(query["age"]);
            if ((UserName != null)&&(UserName!=string.Empty))
                IsUserInfoVisible = true;
        }
        #endregion
    }
}