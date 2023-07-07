using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

using UndoAssessment.Services.Servers;
using Xamarin.Essentials;

namespace UndoAssessment.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusy { get; set;}
        public string Title { get; set; }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void HandleException(Exception exception) 
        {
            Console.WriteLine(exception.Message);

            switch (exception)
            {
                case ServerException serverException:
                    HandleServerException(serverException);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exception), exception);
            }
        }

        private void HandleServerException(ServerException exception)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
                DisplayAlert("Server Error", exception.Message, "OK"));
        }

        protected async void DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

    }
}

