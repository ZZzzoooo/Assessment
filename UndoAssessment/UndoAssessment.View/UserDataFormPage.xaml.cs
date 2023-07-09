using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.View
{
    [PageRegistration(NavigationTag = NavigationTags.UserData)]
    public partial class UserDataFormPage
    {
        public UserDataFormPage()
        {
            InitializeComponent();
        }
    }
}