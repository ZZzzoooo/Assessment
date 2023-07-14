using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.ViewModels;

namespace UndoAssessment.Views
{
	public partial class ItemsPage : ContentPage
	{
		readonly ItemsViewModel _viewModel;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = _viewModel = Startup.ServiceProvider?.GetService<ItemsViewModel>();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}