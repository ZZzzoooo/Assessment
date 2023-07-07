using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Services;
using UndoAssessment.Views;
using UndoAssessment.Services.Servers;

namespace UndoAssessment
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<IServer, Server>();
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

