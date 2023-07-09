using UndoAssessment.Common.Models;
using UndoAssessment.ViewModels;

namespace UndoAssessment.View
{
    public partial class NewItemPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
