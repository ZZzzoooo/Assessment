using Newtonsoft.Json;
using System;
using System.Net.Http;
using UndoAssessment;
using UndoAssessment.Models;
using UndoAssessment.ViewModels;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace Assesment1.ViewModels
{
    public class AssesmentViewModel: BaseViewModel
    {
        public Command SuccessComm { get; }
        public Command FailComm { get; }
        public Command AddCommand { get; }
        HttpClient client;
        public AssesmentViewModel()
        {
            Title = "Assesment";
            SuccessComm = new Command(SuccessCmd);
            FailComm = new Command(FailCmd);
            AddCommand = new Command(OnAdd);
        }
        public async void SuccessCmd()
        {
            client = new HttpClient();
            Uri uri = new Uri(string.Format("https://malkarakundostagingpublicapi.azurewebsites.net/success"));
            
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<GetResult>(responseContent);

                    await App.Current.MainPage.DisplayAlert("Alert", "Result: " + result.message + "\ndate: " + result.date, "OK");
                }
                else
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    await App.Current.MainPage.DisplayAlert("Alert", responseContent, "OK");
                }
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        public async void FailCmd()
        {
            client = new HttpClient();
            Uri uri = new Uri(string.Format("https://malkarakundostagingpublicapi.azurewebsites.net/fail"));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<GetResult>(responseContent);

                    await App.Current.MainPage.DisplayAlert("Alert", "Result: " + result.message + "\ndate: " + result.date, "OK");
                }
                else
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<GetResult>(responseContent);

                    await App.Current.MainPage.DisplayAlert("Alert", "Error Code: " + result.errorCode + "\nResult: " + result.message + "\ndate: " + result.date, "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void OnAdd()
        {
            await Shell.Current.GoToAsync(nameof(NewUserPage));
        }
    }
}
