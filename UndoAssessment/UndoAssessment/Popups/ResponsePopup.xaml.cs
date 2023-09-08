using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResponsePopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ResponsePopup(bool isSuccess, string message)
        {
            InitializeComponent();

            if (isSuccess)
            {
                centerImage.Source = "success";
                resultLabel.Text = "Success";
            }
            else
            {
                centerImage.Source = "fail";
                resultLabel.Text = "Fail";
            }
            descriptionLabel.Text = message;
        }
    }
}