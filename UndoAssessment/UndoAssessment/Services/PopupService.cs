using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UndoAssessment.Popups;

namespace UndoAssessment.Services
{
    public class PopupService : IPopupService
    {
        public void ShowResultPopup(bool isSuccess, string message)
        {
            ResponsePopup popup = new ResponsePopup(isSuccess, message);

            PopupNavigation.Instance.PushAsync(popup, true);
        }

        public void SubmitPopup(ICommand submitCommand)
        {
            SubmitPopup popup = new SubmitPopup(submitCommand);

            PopupNavigation.Instance.PushAsync(popup, true);
        }
    }
}
