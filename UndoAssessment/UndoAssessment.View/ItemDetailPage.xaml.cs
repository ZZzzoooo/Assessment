using UndoAssessment.ViewModels;

namespace UndoAssessment.View
{
    public partial class ItemDetailPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
