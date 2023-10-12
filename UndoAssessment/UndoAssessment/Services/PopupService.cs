using System;
using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public interface IPopupService
    {
        Task ShowMessageAsync(string message);
    }


    public class PopupService : IPopupService
    {
		public PopupService()
		{
		}

        public async Task ShowMessageAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("Message", message, "Ok");
        }
    }
}

