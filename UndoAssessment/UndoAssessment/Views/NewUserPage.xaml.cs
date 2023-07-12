using Xamarin.Forms;
using UndoAssessment.Models;
using UndoAssessment.ViewModels;

namespace UndoAssessment.Views
{
    public partial class NewUserPage : ContentPage
    {
        public User User { get; set; }

        public NewUserPage()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}
