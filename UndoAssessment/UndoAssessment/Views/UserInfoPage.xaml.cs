using System;
using System.ComponentModel;
using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    public partial class UserInfoPage : ContentPage
    {
        public UserInfoPage()
        {
            InitializeComponent();
        }

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text) || string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await DisplayAlert("Validation", "Please enter both name and age.", "OK");
                return;
            }

            if (!int.TryParse(ageEntry.Text, out int age))
            {
                await DisplayAlert("Validation", "Please enter a valid age.", "OK");
                return;
            }

            MessagingCenter.Send(this, "UserDataEntered", new User { Name = nameEntry.Text, Age = age });
            await Navigation.PopAsync();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}