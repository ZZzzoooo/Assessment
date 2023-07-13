using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using UndoAssessment.Models;

namespace UndoAssessment.Views.Dialogs
{
    public partial class EditProfileView : PopupPage
    {
        private readonly IPopupNavigation _popupNavigation;
        private readonly TaskCompletionSource<ProfileModel> _resultTask;
        private ProfileModel _profile;

        //TODO: Extend the logic to support OK and Cancel buttons 
        //TODO: Refactor the code by moving the business logic to VM
        //TODO: Validation
        public EditProfileView(IPopupNavigation popupNavigation, ProfileModel profile = null, TaskCompletionSource<ProfileModel> resultTask = null)
        {
            _resultTask = resultTask;
            _popupNavigation = popupNavigation;
            _profile = profile;
            InitializeComponent();


            if (!string.IsNullOrEmpty(profile?.Name))
            {
                nameEnrtry.IsVisible = true;
                nameEnrtry.Text = profile.Name;
            }

            if (profile != null && profile.Age > 0)
            {
                ageEnrtry.IsVisible = true;
                ageEnrtry.Text = profile.Age.ToString();
            }
            submitButton.Clicked += SubmitButtonClicked;
            cancelButton.Clicked += CancelButtonClicked;
        }

        private async void CancelButtonClicked(object sender, System.EventArgs e)
        {
            _resultTask.SetResult(_profile);
            await _popupNavigation.PopAsync();
        }

        private async void SubmitButtonClicked(object sender, System.EventArgs e)
        {
            var profile = new ProfileModel();
            profile.Age = int.TryParse( ageEnrtry.Text, out int newAge) ? newAge : 0;
            profile.Name = nameEnrtry.Text;

            _resultTask.SetResult(profile);
            await _popupNavigation.PopAsync();
        }
    }
}
