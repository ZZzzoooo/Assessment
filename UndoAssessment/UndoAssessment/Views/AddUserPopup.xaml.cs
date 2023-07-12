using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UndoAssessment.Models;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    public partial class AddUserPopup : Popup
    {
        UserModel obj;
        public AddUserPopup()
        {
            obj=new UserModel();
            InitializeComponent();
            BindingContext = this;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Dismiss(obj);
        }

        private void UserName_Changed(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(UserNameEntry.Text))
            {
                NameLabel.IsVisible = true;
            }
            else
            {
                NameLabel.IsVisible = false;
            }
        }

        private void Age_Changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(AgeEntry.Text))
            {
                AgeLabel.IsVisible = true;
            }
            else
            {
                AgeLabel.IsVisible = false;
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserNameEntry.Text))
            {
                NameLabel.IsVisible = true;
            }
            if (string.IsNullOrEmpty(AgeEntry.Text))
            {
                AgeLabel.IsVisible = true;
            }
            if (!string.IsNullOrEmpty(UserNameEntry.Text) && !string.IsNullOrEmpty(AgeEntry.Text))
            {
                obj.UserName = UserNameEntry.Text;
                obj.Age = Convert.ToInt32(AgeEntry.Text);
                Dismiss(obj);
            }
        }
    }
}