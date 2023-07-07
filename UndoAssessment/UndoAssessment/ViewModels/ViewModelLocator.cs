using System;
using UndoAssessment.Services.Servers;
using UndoAssessment.ViewModels;
using Xamarin.Forms;

namespace UndoAssessment.ViewModels
{
	public class ViewModelLocator
	{
		public ViewModelLocator()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            DependencyService.RegisterSingleton<IServer>(new Server());
        }

        public HomeViewModel Home => new HomeViewModel(DependencyService.Resolve<IServer>());
        public UserFormViewModel UserForm => new UserFormViewModel();
    }
}

