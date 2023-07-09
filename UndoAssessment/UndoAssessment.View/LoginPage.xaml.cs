using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.View
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
