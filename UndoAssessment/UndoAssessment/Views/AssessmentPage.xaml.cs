using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssessmentPage : ContentPage
    {
        AssessmentViewModel _viewModel;
        public AssessmentPage()
        {
            InitializeComponent();
            BindingContext = _viewModel =  new AssessmentViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadUserData();

        }
    }
}