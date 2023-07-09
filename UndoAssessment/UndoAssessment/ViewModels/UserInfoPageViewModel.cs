using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using UndoAssessment.Models;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
	public class UserInfoPageViewModel:BaseViewModel
	{
        #region UserInfo
        private string userName;
        public string UserName { get => userName; set => SetProperty(ref userName, value);}
        private string age;
        public string Age { get => age; set => SetProperty(ref age, value); }         
        #endregion

        public UserInfoPageViewModel()
		{            
            SubmitCommand = new Command(async () => await DoSubmit());           
        }

        #region Command        
        public ICommand SubmitCommand { get; }
        private async Task DoSubmit()
        {
            await Shell.Current.GoToAsync($"..?name={UserName}&age={Age}");
        }
        #endregion
    }
}