using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoFormPage : ContentPage
    {
        public UserInfoFormPage()
        {
            InitializeComponent();
            BindingContext = new UserInfoFormViewModel();
        }
    }
}