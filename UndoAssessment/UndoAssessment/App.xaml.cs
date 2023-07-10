using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UndoAssessment.Services;
using UndoAssessment.Views;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace UndoAssessment
{
    public partial class App : Application, IDialogService
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<DataRepository>();
            DependencyService.Register<UserReopsitory>();
            DependencyService.RegisterSingleton<IDialogService>(this);
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


        //Rather rough but valid MVVM approach to dialog service 
        public async Task ShowDialogAsync(string title, string message, string cancel)
        {
            await this.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}

