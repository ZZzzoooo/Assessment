using System;
using UndoAssessment.Models;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
	public class UserInfoViewModel : BaseViewModel
	{
		public UserInfoViewModel()
		{
            SubmitCommand = new Command(OnSubmit);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private int _age;
        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public Command SubmitCommand { get; }

        private async void OnSubmit(object obj)
        {
            await Shell.Current.GoToAsync($"..?name={UserName}&age={Age}");
        }
    }
}

