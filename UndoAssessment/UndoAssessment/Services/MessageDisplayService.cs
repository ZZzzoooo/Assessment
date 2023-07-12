using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using Xamarin.Essentials;

namespace UndoAssessment.Services
{
    public class MessageDisplayService
    {
        HttpClient client;
        public MessageDisplayService()
        {
            client = new HttpClient();
        }
        public async void SuccessCall()
        {
            string uri = "https://malkarakundostagingpublicapi.azurewebsites.net/success";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<SuccessResult>(content);
                await App.Current.MainPage.DisplayAlert("Success", data.message, "OK");
            }
            else
            {
            }
        }
        public async void FailureCall()
        {
            string uri = "https://malkarakundostagingpublicapi.azurewebsites.net/fail";
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
            }
            else
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ErrorResult>(content);
                await App.Current.MainPage.DisplayAlert("Error", data.message, "OK");
            }
        }
    }
}
