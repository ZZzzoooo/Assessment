using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Models;
using UndoAssessment.ViewModels;

namespace UndoAssessment.Views
{
	public partial class NewItemPage : ContentPage
	{
		public Item Item { get; set; }

		public NewItemPage()
		{
			InitializeComponent();
			BindingContext = Startup.ServiceProvider?.GetService<NewItemViewModel>();
		}
	}
}