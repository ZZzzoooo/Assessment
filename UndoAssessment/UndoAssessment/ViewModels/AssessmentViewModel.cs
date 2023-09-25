using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class AssessmentViewModel : BaseViewModel
    {
        public ICommand SuccessCommand { get; }
        public ICommand FailCommand { get; }

        public AssessmentViewModel()
        {
            Title = "Assessment";
            SuccessCommand = new AsyncCommand(async () => await CallSucc());
            FailCommand = new AsyncCommand(async () => await CallFail());
        }


        public async Task<string> CallSucc()
        {
            throw new NotImplementedException();
        }

        public async Task<string> CallFail()
        {
            throw new NotImplementedException();
        }
    }
}
