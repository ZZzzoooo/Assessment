using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CreateUserPage : ContentPage
{
	public CreateUserPage()
	{
		InitializeComponent();
		BindingContext = Startup.ServiceProvider?.GetService<CreateUserViewModel>();
	}
}