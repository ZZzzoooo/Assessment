using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserInfoPage : ContentPage
    {
        public AddUserInfoPage()
        {
            InitializeComponent();
            BindingContext = new AddUserInfoViewModel();
        }
    }
}