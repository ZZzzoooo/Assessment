using System.Threading.Tasks;
using UndoAssessment.Models;
using UndoAssessment.Models.Data;

namespace UndoAssessment.Services.Dialog
{
    public interface IDialogsService
    {
        Task ShowAlertAsync(BaseDataModel model);
        Task<ProfileModel> ShowProfileDialogAsync(ProfileModel profileModel = null);
    }
}
