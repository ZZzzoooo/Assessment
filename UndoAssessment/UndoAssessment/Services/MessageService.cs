using System.Threading.Tasks;

namespace UndoAssessment.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowMessage(string message)
        {
            await App.Current.MainPage.DisplayAlert("Message", message, "OK");
        }
    }
}
