using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.ViewModels
{
    [ViewModelRegistration(NavigationTag = NavigationTags.Main)]
    public class AppShellViewModel : BaseViewModel
    {
    }
}