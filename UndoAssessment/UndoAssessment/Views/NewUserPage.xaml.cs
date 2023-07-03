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
    public partial class NewUserPage : ContentPage
    {
        private NewUserViewModel _newUserViewModel;
        public NewUserPage()
        {
            InitializeComponent();
            _newUserViewModel = new NewUserViewModel();
            BindingContext = _newUserViewModel;
        }
    }
}