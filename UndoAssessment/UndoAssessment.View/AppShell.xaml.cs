using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.View
{
    [PageRegistration(NavigationTag = NavigationTags.Main)]
    public partial class AppShell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}

