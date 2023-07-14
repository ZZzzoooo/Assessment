using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AssessmentPage : ContentPage
{
	readonly AssessmentViewModel _viewModel;

	public AssessmentPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = Startup.ServiceProvider?.GetService<AssessmentViewModel>();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadUser();
	}
}