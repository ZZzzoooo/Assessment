using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Services;
using UndoAssessment.Services.Api;
using UndoAssessment.Services.Dialogs;
using UndoAssessment.Services.Storage;
using UndoAssessment.Views;

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

