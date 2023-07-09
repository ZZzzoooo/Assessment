using System;
using Autofac;
using UndoAssessment.Api;
using UndoAssessment.Common.Models;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation;
using UndoAssessment.Domain.Navigation.Types;
using UndoAssessment.Modules;
using UndoAssessment.Service.Contract.Dialogs;
using UndoAssessment.Service.Contract.Storage;
using Xamarin.Forms;
using UndoAssessment.Services.Dialogs;
using UndoAssessment.Services.Storage;
using UndoAssessment.View;
using UndoAssessment.ViewModels;

namespace UndoAssessment
{
    public partial class App : Application
    {
        public static IContainer Scope;
        
        public App()
        {
            InitializeComponent();
            RegisterDependencies();
            MainPage = new NavigationPage(new ContentPage());
        }

        protected override void OnStart()
        {
            var navService = Scope.Resolve<INavigationService>();
            navService.NavigateToRootAsync(NavigationTags.Main);
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterDependencies()
        {
            Console.WriteLine(typeof(LoginViewModel).Assembly.FullName);
            Console.WriteLine(typeof(LoginPage).Assembly.FullName);
            
            var container = new ContainerBuilder();
            container.RegisterModule<NavigationModule>();
            container.RegisterType<MockDataStore>().As<IDataStore<Item>>().SingleInstance();
            container.RegisterType<TaskApiService>().As<IApiService>().SingleInstance();
            container.RegisterType<UserDialogsService>().As<IDialogsService>().SingleInstance();
            container.Register(c => new NavigationProvider(() => MainPage.Navigation));
            container.Register(c => new AppProvider(() => this));
            container.Register(c => new TypeResolver(() => Scope)).SingleInstance();
            Scope = container.Build();
        }
    }
}

