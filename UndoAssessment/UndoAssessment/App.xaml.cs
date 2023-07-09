using UndoAssessment.Services;
using Xamarin.Forms;

namespace UndoAssessment
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();
            DependencyService.Register<IServiceApi, ServiceApi>();
            DependencyService.Register<MockDataStore>();
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