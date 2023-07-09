using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.View
{
    public partial class TaskPage : ContentPage
    {
        private TaskViewModel _viewModel;
        
        public TaskPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TaskViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}