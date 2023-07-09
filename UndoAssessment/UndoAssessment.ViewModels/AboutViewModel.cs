using System.Windows.Input;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Common.Tools;
using UndoAssessment.Domain.Navigation.Attributes;
using Xamarin.Essentials;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.AboutPage)]
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
