using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using UndoAssessment.Models;
using UndoAssessment.Services;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace UndoAssessment.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        private IServiceApi serviceApi;
        protected IServiceApi ServiceApi => serviceApi = DependencyService.Get<IServiceApi>();

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

        #region PreProcessing
        /// <summary>
        /// This Task is for open loader and set busy state when call Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="busyState"></param>
        /// <param name="showLoading"></param>
        /// <param name="showDialogMessage"></param>
        /// <returns></returns>
        protected async Task<T> PreProcessing<T>(Func<Task<T>> func,
           bool busyState = true, bool showLoading = true, bool showDialogMessage = false)
        {
            if (showLoading)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    UserDialogs.Instance.ShowLoading();
                    Task.Delay(6000); //Simulate the time for call to response
                });
            }
            try
            {
                if (busyState)
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
                        await UserDialogs.Instance.AlertAsync(e.Message);

                    return default;
                }
            }
            finally
            {
                if (busyState)
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
        #endregion
    }
}