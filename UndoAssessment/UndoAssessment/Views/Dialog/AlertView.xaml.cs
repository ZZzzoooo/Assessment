using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;

namespace UndoAssessment.Views.Dialogs
{
    public partial class AlertView : PopupPage
    {
        private readonly IPopupNavigation _popupNavigation;
        private readonly TaskCompletionSource<bool> _resultTask;

        //TODO: Extend the logic to support OK and Cancel buttons 
        //TODO: Refactor the code by moving the business logic to VM
        public AlertView(IPopupNavigation popupNavigation, string message, string title, string subTitle = null, TaskCompletionSource<bool> resultTask = null)
        {
            _resultTask = resultTask;
            _popupNavigation = popupNavigation;
            InitializeComponent();


            if (!string.IsNullOrEmpty(title))
            {
                titleLabel.IsVisible = true;
                titleLabel.Text = title;
            }

            if (!string.IsNullOrEmpty(message))
            {
                messageLabel.IsVisible = true;
                messageLabel.Text = message;
            }

            if (!string.IsNullOrEmpty(subTitle))
            {
                subtitleLabel.IsVisible = true;
                subtitleLabel.Text = subTitle;
            }

            okButton.Text = "Ok";
            okButton.Clicked += OkButtonClicked;
        }

        private async void OkButtonClicked(object sender, System.EventArgs e)
        {
            await _popupNavigation.PopAsync();
            _resultTask.SetResult(true);
        }
    }
}
