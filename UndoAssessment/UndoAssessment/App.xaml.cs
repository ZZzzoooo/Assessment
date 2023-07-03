using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Services;
using UndoAssessment.Views;
using System.Security.Authentication.ExtendedProtection;

namespace UndoAssessment
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>(); // This approach is suitable only for smaller projects. For bigger project, it's better to use DI container.
            DependencyService.Register<ApiService>();

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

