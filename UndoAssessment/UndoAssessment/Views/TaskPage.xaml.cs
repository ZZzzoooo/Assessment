using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
            BindingContext = new TaskViewModel();
        }
    }
}