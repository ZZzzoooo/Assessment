using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class TestPage : ContentPage
    {
        TestViewModel _viewModel;

        public TestPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TestViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
