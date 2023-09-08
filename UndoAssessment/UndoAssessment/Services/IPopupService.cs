using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UndoAssessment.Popups;

namespace UndoAssessment.Services
{
    internal interface IPopupService
    {
        void ShowResultPopup(bool isSuccess, string message);

        void SubmitPopup(ICommand submitCommand);
    }
}
