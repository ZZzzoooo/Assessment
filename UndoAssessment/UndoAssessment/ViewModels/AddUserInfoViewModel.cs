using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UndoAssessment.ViewModels
{
    public class AddUserInfoViewModel : BaseViewModel
    {
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        private string _userName;

        public string Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        private string _age;

        public Command SubmitUserInfoCommand { get; }
        public AddUserInfoViewModel()
        {
            SubmitUserInfoCommand = new Command(OnSumbitUserInfo);
        }

        private async void OnSumbitUserInfo(object obj)
        {
            Preferences.Set(nameof(UserName), UserName);
            Preferences.Set(nameof(Age), Age);
            await Shell.Current.GoToAsync("..");
        }
    }
}
