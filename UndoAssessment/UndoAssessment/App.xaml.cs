using UndoAssessment.Services;
using UndoAssessment.Services.DataProvider;
using Xamarin.Forms;

namespace UndoAssessment
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockItemDataStore>();
            DependencyService.Register<MockUserDataStore>();
            DependencyService.Register<DataProvider>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

