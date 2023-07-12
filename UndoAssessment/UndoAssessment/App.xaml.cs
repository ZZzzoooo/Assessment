using Xamarin.Forms;
using UndoAssessment.Services;
using UndoAssessment.Views;

namespace UndoAssessment
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<AssessmentService>();
            DependencyService.Register<RequestProvider.RequestProvider>();
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

