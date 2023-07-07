using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UndoAssessment.Models;
using UndoAssessment.Views;
using UndoAssessment.ViewModels;
using UndoAssessment.Services;

namespace UndoAssessment.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        PublicApi publicApi;
        public ItemsPage(PublicApi publicApi)
        {
            InitializeComponent();
            this.publicApi = publicApi;
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private async void Success_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await publicApi.GetSuccess();
                await DisplayAlert("Get success", $"Message: {result.Message}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error during call api", $"Message: {ex.Message}", "OK");
            }
        }

        private async void Fail_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await publicApi.GetFail();

                await DisplayAlert("Get fail", $"Message: {result.Message}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error during call api", $"Message: {ex.Message}", "OK");
            }
        }
    }
}
