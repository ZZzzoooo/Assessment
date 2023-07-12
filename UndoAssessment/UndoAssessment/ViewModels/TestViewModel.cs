using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UndoAssessment.Models;
using UndoAssessment.Views;
using UndoAssessment.Services;
using System.Text.RegularExpressions;

namespace UndoAssessment.ViewModels
{
    public class TestViewModel : BaseViewModel<User>
    {
        private User _selectedUser;

        public ObservableCollection<User> Users { get; }
        public Command LoadUsersCommand { get; }
        public Command AddUserCommand { get;  }

        public Command SuccessEndpointCommand { get; }
        public Command FailEndpointCommand { get; }

        public IApiService ApiService => DependencyService.Get<IApiService>();
        public IMessageService MessageService => DependencyService.Get<IMessageService>();

        private const string uriSuccess = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
        private const string uriFail = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";

        public TestViewModel()
        {
            Title = "Test";
            Users = new ObservableCollection<User>();
            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());

            AddUserCommand = new Command(OnAddUser);

            SuccessEndpointCommand = new Command(async () => await OnInvokeSuccessEndpoint());

            FailEndpointCommand = new Command(async () => await OnInvokeFailEndpoint());
        }

        async Task ExecuteLoadUsersCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Users.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnAddUser(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }

        async Task OnInvokeSuccessEndpoint()
        {
            IsBusy = true;

            try
            {
                var content = await ApiService.GetContent(uriSuccess);
                var message = getMessageFromContent(content);
                if (!string.IsNullOrEmpty(message))
                {
                    await MessageService.ShowMessage(message);
                }
                else
                {
                    Debug.WriteLine("Success message didn't receive");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task OnInvokeFailEndpoint()
        {
            IsBusy = true;

            try
            {
                var content = await ApiService.GetContent(uriFail);
                var message = getMessageFromContent(content);
                if (!string.IsNullOrEmpty(message))
                {
                    await MessageService.ShowMessage(message);
                }
                else
                {
                    Debug.WriteLine("Fail message didn't receive");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Get message text from Api response content
        /// </summary>
        /// <param name="context">Api response content</param>
        /// <returns>Message text from response</returns>
        private string getMessageFromContent(string content)
        {
            return Regex.Match(content, "(?<=\"message\":\")(.*)(?=\",)").ToString();
        }
    }
}
