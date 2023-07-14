using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiCall : ContentPage
    {
        public ApiCall()
        {
            InitializeComponent();
        }
        private async void onSuccessBtnClicked(object sender, System.EventArgs e)
        {
            await CallApi("https://malkarakundostagingpublicapi.azurewebsites.net/success");
        }

        private async void onFailBtnClicked(object sender, System.EventArgs e)
        {
            await CallApi("https://malkarakundostagingpublicapi.azurewebsites.net/fail");
        }
        private async Task CallApi(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            string alertTitle = response.IsSuccessStatusCode ? "Success" : "Error";
            string alertMessage = response.IsSuccessStatusCode ? "Call succeeded" : "Call failed";

            await DisplayAlert(alertTitle, alertMessage, "OK");
        }

        private void OnUserInfoButtonClicked(object sender, EventArgs e)
        {
            userInfoForm.IsVisible = true;
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            userInfoForm.IsVisible = false;
            userInfoLabel.IsVisible = true;
            userInfoLabel.Text = $"Name : {entName.Text} Age: {entAge.Text}";
        }
    }
}