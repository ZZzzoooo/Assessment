using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        public Command SuccessCommand { get; }
        public Command ErrorCommand { get; }

        public TaskViewModel()
        {
            SuccessCommand = new Command(OnSuccessCommand);
            ErrorCommand = new Command(OnErrorCommand);
        }

        private async void OnSuccessCommand()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (Debugger.IsAttached)
                    Debugger.Break();
            }
        }

        private async void OnErrorCommand()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (Debugger.IsAttached)
                    Debugger.Break();
            }
        }
    }
}