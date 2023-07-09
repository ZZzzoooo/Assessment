using UndoAssessment.Api;
using Xamarin.Forms;
using UndoAssessment.Services.Dialogs;
using UndoAssessment.Services.Storage;

namespace UndoAssessment
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<TaskApiService>();
            DependencyService.Register<UserDialogsService>();
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

