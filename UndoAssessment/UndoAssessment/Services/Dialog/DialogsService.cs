using Rg.Plugins.Popup.Contracts;
using System;
using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Models.Data;
using UndoAssessment.Views.Dialogs;

namespace UndoAssessment.Services.Dialog
{
    public class DialogsService: IDialogsService
    {
        private readonly IPopupNavigation _popupNavigation;
        private TaskCompletionSource<int> _dialogsBlockerTcs = new TaskCompletionSource<int>();
        private Task _currentShownDialogTask;

        public DialogsService(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;
        }

        #region -- IDialogService implementations --

        public Task ShowAlertAsync(BaseDataModel model)
        {
            var taskResult = new TaskCompletionSource<bool>();
            string subtitle = null;
            if (model is FailureModel)
                subtitle = (model as FailureModel).ErrorCode.ToString();

            _popupNavigation.PushAsync(new AlertView(_popupNavigation, model.Date, model.Message, subtitle, taskResult), true);
            return ShowDialogAsync(taskResult.Task);
        }

        public Task<ProfileModel> ShowProfileDialogAsync(ProfileModel profileModel = null)
        {
            var taskResult = new TaskCompletionSource<ProfileModel>();
            _popupNavigation.PushAsync(new EditProfileView(_popupNavigation, profileModel, taskResult), true);
            return ShowDialogAsync(taskResult.Task);
        }

        #endregion

        #region -- Private helpers --

        private async Task<T> ShowDialogAsync<T>(Task<T> dialogTask)
        {
            _currentShownDialogTask = dialogTask;
            var result = await dialogTask;

            return result;
        }

        #endregion
    }
}