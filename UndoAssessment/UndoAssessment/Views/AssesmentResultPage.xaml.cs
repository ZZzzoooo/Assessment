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
    public partial class AssesmentResultPage : ContentPage
    {
        private AssesmentResultViewModel _assesmentResultViewModel;
        public AssesmentResultPage()
        {
            InitializeComponent();
            _assesmentResultViewModel = new AssesmentResultViewModel();
            BindingContext = _assesmentResultViewModel;
        }
    }
}