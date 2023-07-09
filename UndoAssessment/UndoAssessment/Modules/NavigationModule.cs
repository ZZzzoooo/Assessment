using Autofac;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain;
using UndoAssessment.Domain.Navigation;
using UndoAssessment.Domain.Navigation.Attributes;
using UndoAssessment.Domain.Navigation.Builders;
using UndoAssessment.Domain.Navigation.Holders;
using UndoAssessment.Domain.Navigation.Types;
using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.Modules
{
    public class NavigationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterPages(builder);
            RegisterViewModels(builder);
            
            builder.RegisterType<PageBuilder>().As<IPageBuilder>();
            builder.RegisterType<ViewModelBuilder>().As<IViewModelBuilder>();
            
            builder.RegisterType<NavigationPage>().Named<Page>("nav").InstancePerRequest();
            
            builder.RegisterType<NavigationService>().As<INavigationService>().InstancePerLifetimeScope();
            builder.RegisterDecorator<ShellContentInitNavigationServiceDecorator, INavigationService>();
        }

        private void RegisterPages(ContainerBuilder builder)
        {
            var typesProvider = new RegisteredNavigationTypesProvider();
            var typeRegistrations = typesProvider.GetRegistrations<PageRegistrationAttribute>("UndoAssessment.View,");

            foreach (var typeRegistration in typeRegistrations)
                builder.RegisterType(typeRegistration.Type).Named<Page>(typeRegistration.Tag).ExternallyOwned();

            builder.Register(c => new PageNavigationTypeHolder(typeRegistrations));
        }

        private void RegisterViewModels(ContainerBuilder builder)
        {
            var typesProvider = new RegisteredNavigationTypesProvider();
            var typeRegistrations = typesProvider.GetRegistrations<ViewModelRegistrationAttribute>("UndoAssessment.ViewModels");

            foreach (var typeRegistration in typeRegistrations)
                builder.RegisterType(typeRegistration.Type).Named<ViewModelAbstract>(typeRegistration.Tag).ExternallyOwned();

            builder.Register(c => new ViewModelNavigationTypeHolder(typeRegistrations));
        }
    }
}