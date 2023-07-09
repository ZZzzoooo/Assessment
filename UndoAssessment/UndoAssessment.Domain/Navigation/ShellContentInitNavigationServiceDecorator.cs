using System.Collections.Generic;
using System.Threading.Tasks;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Builders;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation
{
    public class ShellContentInitNavigationServiceDecorator : INavigationService
    {
        private readonly INavigationService _navigationService;
        private readonly AppProvider _appProvider;
        private readonly IViewModelBuilder _viewModelBuilder;

        public ShellContentInitNavigationServiceDecorator(
            INavigationService navigationService,
            AppProvider appProvider,
            IViewModelBuilder viewModelBuilder)
        {
            _navigationService = navigationService;
            _appProvider = appProvider;
            _viewModelBuilder = viewModelBuilder;
        }

        public async Task NavigateToRootAsync(string tag, params KeyValuePair<string, object>[] parameters)
        {
            await _navigationService.NavigateToRootAsync(tag, parameters);
            if (_appProvider.GetApplication().MainPage is Shell shell)
                InitializeViewModelsForContents(shell);
        }

        private void InitializeViewModelsForContents(Shell shellPage)
        {
            foreach (var item in shellPage.Items)
                InitializeViewModelsForSHallItem(item);
        }

        private void InitializeViewModelsForSHallItem(ShellItem item)
        {
            foreach (var i in item.Items)
                if (!string.IsNullOrEmpty(i.CurrentItem.Route))
                    i.BindingContext = _viewModelBuilder.BuildViewModel(i.CurrentItem.Route);
        }

        public Task NavigateAsync(string tag, params KeyValuePair<string, object>[] parameters)
        {
            return _navigationService.NavigateAsync(tag, parameters);
        }

        public Task NavigateBackAsync(params KeyValuePair<string, object>[] parameters)
        {
            return _navigationService.NavigateBackAsync(parameters);
        }
    }
}