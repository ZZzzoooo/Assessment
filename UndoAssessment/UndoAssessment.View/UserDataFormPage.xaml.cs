using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.View
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