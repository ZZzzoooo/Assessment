using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{

    public partial class CatePage : ContentPage
    {

        private HttpClient httpClient; // HTTP client for API requests

        public CatePage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async void OnSuccessButtonClicked(object sender, EventArgs e)
        {
            await InvokeApiEndpoint("https://malkarakundostagingpublicapi.azurewebsites.net/success");
        }

        private async void OnFailButtonClicked(object sender, EventArgs e)
        {
            await InvokeApiEndpoint("https://malkarakundostagingpublicapi.azurewebsites.net/fail");
        }

        private void OnUserInfoButtonClicked(object sender, EventArgs e)
        {
            userInfoLayout.IsVisible = true;
        }

        private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string age = ageEntry.Text;

            userInfoLabel.Text = $"Name: {name}\nAge: {age}";
            userInfoLabel.IsVisible = true;
            userInfoLayout.IsVisible = false;
        }

        private async Task InvokeApiEndpoint(string url)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Show success message
                    
                    await DisplayAlert("Success", "API call successful\n" + await response.Content.ReadAsStringAsync(), "OK");
                }
                else
                {
                    // Show error message
                    await DisplayAlert("Error", "API call failed\n" + await response.Content.ReadAsStringAsync(), "OK");
                }
            }
            catch (Exception ex)
            {
                // Show exception message
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}