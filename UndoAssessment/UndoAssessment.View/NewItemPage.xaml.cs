using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.View
{
    [PageRegistration(NavigationTag = NavigationTags.NewItem)]
    public partial class NewItemPage
    {
        public NewItemPage()
        {
            InitializeComponent();
        }
    }
}
