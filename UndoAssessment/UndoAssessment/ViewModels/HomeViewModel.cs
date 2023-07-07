using System;
using System.Threading.Tasks;
using UndoAssessment.Services.Servers;
using UndoAssessment.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    [QueryProperty(nameof(UserName), "UserName")]
    [QueryProperty(nameof(UserAge), "UserAge")]
    public class HomeViewModel : BaseViewModel
    {
        private string userName;

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public int UserAge { get; set; }

        private IServer Server { get; }

        public IAsyncCommand OpenUserFormCommand   { get; }
        public IAsyncCommand RequestSuccessCommand { get; }
        public IAsyncCommand RequestFailureCommand { get; }

		public HomeViewModel(IServer server)
		{
            Server = server;
            OpenUserFormCommand   = CommandFactory.Create(OpenUserFormAsync, onException: HandleException, allowsMultipleExecutions: false);
            RequestSuccessCommand = CommandFactory.Create(RequestSuccessAsync, onException: HandleException, allowsMultipleExecutions: false);
            RequestFailureCommand = CommandFactory.Create(RequestFailureAsync, onException: HandleException, allowsMultipleExecutions: false);
        }

        private async Task RequestSuccessAsync()
        {
            await Server.GetSuccessAsync();
        }

        private async Task RequestFailureAsync()
        {
            await Server.GetFailureAsync();
        }

        private async Task OpenUserFormAsync()
        {
            await Shell.Current.GoToAsync($"//{nameof(UserFormPage)}");
        }
    }
}

