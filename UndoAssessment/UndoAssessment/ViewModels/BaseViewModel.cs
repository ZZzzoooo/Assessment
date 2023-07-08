using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using UndoAssessment.Models;
using UndoAssessment.Services;
using System.Threading.Tasks;
using Acr.UserDialogs;
using AsyncAwaitBestPractices;
using UndoAssessment.Services.Interfaces;

namespace UndoAssessment.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private IApiService _apiService;
        protected IApiService ApiService => _apiService ??= DependencyService.Get<IApiService>();

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected async Task<T> TryDataProcessing<T>(Func<Task<T>> func,
           bool presentBusyState = true, bool showLoading = true, bool showDialogMessage = false)
        {
            if (showLoading)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UserDialogs.Instance.ShowLoading();
                });
            }
            try
            {
                if (presentBusyState) 
                    IsBusy = true;

                T result;
                try
                {
                    result = await func();
                    return result;
                }
                catch (Exception e)
                {
                    if (showDialogMessage)
                        UserDialogs.Instance.AlertAsync(e.Message).SafeFireAndForget();

                    return default;
                }
            }
            finally
            {
                if (presentBusyState)
                    IsBusy = false;

                if (showLoading)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UserDialogs.Instance.HideLoading();
                    });
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

