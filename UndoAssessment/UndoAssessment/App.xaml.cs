using Xamarin.Forms;
using UndoAssessment.Services;
using UndoAssessment.Services.Rest;
using UndoAssessment.Services.Dialog;
using Rg.Plugins.Popup.Services;

namespace UndoAssessment
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.RegisterSingleton<IRestService>(new RestService());
            DependencyService.RegisterSingleton<IDialogsService>(new DialogsService(PopupNavigation.Instance));
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

