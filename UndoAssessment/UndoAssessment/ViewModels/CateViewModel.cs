using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
    public class CateViewModel : BaseViewModel
    {
        public CateViewModel()
        {
            Title = "Assessment for Cate";
        }

        public ICommand OpenWebCommand { get; }
    }
}
