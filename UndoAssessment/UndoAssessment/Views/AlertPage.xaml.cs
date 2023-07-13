using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Services;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    public partial class AlertPage : ContentPage
    {
        public AlertPage()
        {
            InitializeComponent();
        }

        private void SuccessButton_Clicked(object sender, EventArgs e)
        {
            MessageDisplayService msg = new MessageDisplayService();
            msg.SuccessCall();
        }

        private void FailureButton_Clicked(object sender, EventArgs e)
        {
            MessageDisplayService msg = new MessageDisplayService();
            msg.FailureCall();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var result = await Navigation.ShowPopupAsync(new AddUserPopup());
            user = result as UserModel;
            if(user.UserName != null && user.Age != null)
            {
                UserNameFrame.IsVisible= true;
                AgeFrame.IsVisible = true;
                UserNameLabel.Text= user.UserName;
                AgeLabel.Text = user.Age.ToString();
            }
        }
    }
}