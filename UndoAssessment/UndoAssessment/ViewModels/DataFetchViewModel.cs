using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UndoAssessment.Models;
using UndoAssessment.Services;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class DataFetchViewModel : BaseViewModel, INavigateable
    {
        private DataRepository repository;
        private UserReopsitory userReopsitory;
        private IDialogService dialogService;
        private CancellationTokenSource cancellationTokenSource;

        public Command FetchSuccessfulCommand { get; }
        public Command FetchFailedCommand { get; }
        public Command AddUserDataCommand { get; }

        private int age;
        public int Age { get => age; set => SetProperty(ref age, value); }

        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        public DataFetchViewModel()
        {
            Title = "Read Data";

            repository = DependencyService.Resolve<DataRepository>();
            userReopsitory = DependencyService.Resolve<UserReopsitory>();
            dialogService = DependencyService.Resolve<IDialogService>();

            FetchSuccessfulCommand = new Command(OnFetchSuccessful);
            FetchFailedCommand = new Command(OnFetchFailed);

            AddUserDataCommand = new Command(OnAddUser);

            RefreshUser();
        }

        public void OnNaviageted()
        {
            RefreshUser();
        }

        private async void OnAddUser(object obj)
        {
            await Shell.Current.GoToAsync(nameof(UserDataPage));
        }

        private async void OnFetchSuccessful(object obj)
        {
            cancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var data = await repository.GetSuccess(cancellationTokenSource.Token);

            await dialogService.ShowDialogAsync("Success", data.Message, "Ok");

            IsBusy = false;
        }

        private async void OnFetchFailed(object obj)
        {
            cancellationTokenSource = new CancellationTokenSource();

            IsBusy = true;

            var data = await repository.GetFailed(cancellationTokenSource.Token);

            await dialogService.ShowDialogAsync("Error", data.Message, "Ok");

            IsBusy = false;
        }

        private void RefreshUser()
        {
            var user = userReopsitory.ReadUser();

            Age = user.Age;
            Name = user.Name;
        }
    }
}
