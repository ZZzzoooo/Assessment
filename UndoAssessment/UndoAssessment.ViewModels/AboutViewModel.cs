using System.Windows.Input;
using UndoAssessment.Common.Tools;
using Xamarin.Essentials;

namespace UndoAssessment.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new AsyncCommand(() => Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

    }
}
