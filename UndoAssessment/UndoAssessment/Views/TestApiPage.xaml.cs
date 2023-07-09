using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Views
{
    public partial class TestApiPage : ContentPage
	{
		public TestApiPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
            BindingContext = new TestApiPageViewModel();
        }
	}
}