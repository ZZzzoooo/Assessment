using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UndoAssessment.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly IPopupService _popupService;
        ICommand _submitCommand;

        public SubmitPopup(ICommand submitCommand)
        {
            InitializeComponent();
            _popupService = DependencyService.Get<IPopupService>();
            _submitCommand = submitCommand;
        }

        private void SubmitButton_Clicked(object sender, System.EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameEntry.Text) || String.IsNullOrEmpty(ageEntry.Text))
            {
                _popupService.ShowResultPopup(false, "Please fill all fields");
                return;
            }

            PopupNavigation.Instance.PopAllAsync();

            object[] userInformationArray = new object[] { usernameEntry.Text, ageEntry.Text };
            _submitCommand?.Execute(userInformationArray);
        }
    }
}