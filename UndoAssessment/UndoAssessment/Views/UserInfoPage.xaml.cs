using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class UserInfoPage : ContentPage
	{	
		public UserInfoPage ()
		{
			InitializeComponent ();            
            BindingContext = new UserInfoPageViewModel();
        }
	}
}