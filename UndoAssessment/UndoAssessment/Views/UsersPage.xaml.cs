using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class UsersPage : ContentPage
    {
        private readonly UsersViewModel _viewModel;

        public UsersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new UsersViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.OnAppearing();
        }
    }
}