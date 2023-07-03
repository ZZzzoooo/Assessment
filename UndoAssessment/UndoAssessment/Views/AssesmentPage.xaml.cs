using Assesment1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssesmentPage : ContentPage
    {
        private AssesmentViewModel _assesmentViewModel;
        public AssesmentPage()
        {
            InitializeComponent();
            _assesmentViewModel = new AssesmentViewModel();
            BindingContext = _assesmentViewModel;

            menuItem1.Source = ImageSource.FromResource("UndoAssessment.Image.check.png");
            menuItem2.Source = ImageSource.FromResource("UndoAssessment.Image.cross.jpeg");
        }

        public void GoSuccess(object sender, EventArgs args)
        {
            _assesmentViewModel.SuccessCmd();
        }

        public void GoFail(object sender, EventArgs args)
        {
            _assesmentViewModel.FailCmd();
        }
    }
}