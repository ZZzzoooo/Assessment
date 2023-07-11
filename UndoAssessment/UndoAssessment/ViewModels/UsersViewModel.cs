using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    internal class UsersViewModel : CollectionViewModel<User>
    {
        public Command ButtonCommand { get; }

        public UsersViewModel()
        {
            ButtonCommand = new Command<bool>(OnFirstClicked);
        }

        private async void OnFirstClicked(bool flag)
        {
            await MakeApiCall(flag);
        }

        public async Task MakeApiCall(bool flag)
        {
            if (flag)
                IsSuccessBusyVisible = true;
            else
                IsFailBusyVisible = true;

            try
            {
                var response = await DataProvider.MakeApiRequest(flag);

                // Check if the API call was successful
                if (response.IsSuccess)
                {
                    // Show success message
                    await ShowAlert("Success", $"API call was successful: {response.Result}");
                }
                else
                {
                    // Show error message
                    await ShowAlert("Error", response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await ShowAlert("Error", ex.Message);
            }
            finally
            {
                IsSuccessBusyVisible = false;
                IsFailBusyVisible = false;
            }
        }

        bool _isSuccessBusyVisible = false;
        public bool IsSuccessBusyVisible
        {
            get => _isSuccessBusyVisible;
            set => SetProperty(ref _isSuccessBusyVisible, value);
        }

        bool _isFailBusyVisible = false;
        public bool IsFailBusyVisible
        {
            get => _isFailBusyVisible;
            set => SetProperty(ref _isFailBusyVisible, value);
        }

        public async Task ShowAlert(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }

        protected override async Task<IEnumerable<User>> LoadDataStore()
        {
            return await UserDataStore.GetItemsAsync(true);
        }

        protected override async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }

        protected override async void OnItemSelected(User item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={item.Id}");
        }
    }
}
