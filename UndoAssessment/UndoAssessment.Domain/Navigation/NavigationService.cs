using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain.Navigation.Builders;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationProvider _navigationProvider;
        private readonly AppProvider _appProvider;
        private readonly IPageBuilder _pageBuilder;
        private readonly IViewModelBuilder _viewModelBuilder;

        private INavigation Navigation => _navigationProvider.GetNavigation();
        
        public NavigationService(
            NavigationProvider navigationProvider,
            AppProvider appProvider,
            IPageBuilder pageBuilder,
            IViewModelBuilder viewModelBuilder)
        {
            _navigationProvider = navigationProvider;
            _appProvider = appProvider;
            _pageBuilder = pageBuilder;
            _viewModelBuilder = viewModelBuilder;
        }

        public async Task NavigateToRootAsync(string tag, params KeyValuePair<string, object>[] parameters)
        {
            var data = GetNavigationData(parameters);
            var nextPage = _pageBuilder.BuildPage(tag);
            var nextPageViewModel = _viewModelBuilder.BuildViewModel(tag);
            nextPage.BindingContext = nextPageViewModel;
            _appProvider.GetApplication().MainPage = nextPage;
            await Navigation.PopAsync();
            if (nextPageViewModel is INavigated nav)
                await nav.NavigatedAsync(data);
        }

        public async Task NavigateAsync(string tag, params KeyValuePair<string, object>[] parameters)
        {
            var data = GetNavigationData(parameters);
            var nextPage = _pageBuilder.BuildPage(tag);
            var nextPageViewModel = _viewModelBuilder.BuildViewModel(tag);
            nextPage.BindingContext = nextPageViewModel;
            await Navigation.PushAsync(nextPage);
            if (nextPageViewModel is INavigated nav)
                await nav.NavigatedAsync(data);
        }

        public async Task NavigateBackAsync(params KeyValuePair<string, object>[] parameters)
        {
            var data = GetNavigationData(parameters);
            await Navigation.PopAsync();
            var currentPage = Navigation.CurrentPage();
            if (currentPage?.BindingContext is INavigated nav)
                await nav.NavigatedAsync(data);
            if (currentPage == null && _appProvider.GetApplication().MainPage is Shell shell && shell.Items[0].CurrentItem.BindingContext is INavigated n)
                await n.NavigatedAsync(data);
        }

        private NavigationData GetNavigationData(KeyValuePair<string, object>[] parameters)
        {
            parameters = parameters ?? new KeyValuePair<string, object>[0];
            return new NavigationData(parameters.ToDictionary(k => k.Key, v => v.Value));
        }
    }
}