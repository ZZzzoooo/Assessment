using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.View
{
    [PageRegistration(NavigationTag = NavigationTags.ItemDetails)]
    public partial class ItemDetailPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
        }
    }
}
