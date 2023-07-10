using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UndoAssessment.Services;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class DataFetchViewModel : BaseViewModel
    {
        private DataRepository repository;
        private IDialogService dialogService;
        private CancellationTokenSource cancellationTokenSource;

        public Command FetchSuccessfulCommand { get; }
        public Command FetchFailedCommand { get; }

        public DataFetchViewModel()
        {
            Title = "Read Data";

            repository = DependencyService.Resolve<DataRepository>();
            dialogService= DependencyService.Resolve<IDialogService>();

            FetchSuccessfulCommand = new Command(OnFetchSuccessful);
            FetchFailedCommand = new Command(OnFetchFailed);
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
    }
}
