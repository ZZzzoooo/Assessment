using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class UserDataFormPage : ContentPage
    {
        public UserDataFormPage()
        {
            InitializeComponent();
            BindingContext = new UserDataFormViewModel();
        }
    }
}