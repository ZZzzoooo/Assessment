using System;
using System.Collections.Generic;
using System.Text;
using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace Assesment1.ViewModels
{
    [QueryProperty(nameof(User), nameof(User))]
    public class AssesmentResultViewModel: BaseViewModel
    {
        public Command BackToComm { get; }
        public AssesmentResultViewModel() 
        {
            Title = "Assesment Result";

            BackToComm = new Command(BackToCmd);
        }

        private async void BackToCmd()
        {
            await Shell.Current.GoToAsync("//AssesmentPage");
        }

        public string User
        {            
            set
            {
                UserName = value;
            }
        }

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
    }
}
