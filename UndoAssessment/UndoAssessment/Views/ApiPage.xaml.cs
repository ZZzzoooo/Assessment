using System;
using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Models;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        private ApiPageViewModel _viewModel;

        public ApiPage()
        {
            InitializeComponent();
            _viewModel = new ApiPageViewModel();
            BindingContext = _viewModel;
        }

        private async void OnSuccessButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.InvokeSuccessEndpoint();
        }

        private async void OnFailButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.InvokeFailEndpoint();
        }

        private async void OnAddUserButtonClicked(object sender, EventArgs e)
        {
            await _viewModel.AddUserInformation();
            userDataLayout.IsVisible = !string.IsNullOrWhiteSpace(_viewModel.User.Name) || !string.IsNullOrWhiteSpace(_viewModel.User.Age);
            Console.WriteLine("--------------------");
        }
    }
}
