using System;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation
{
    public class NavigationProvider
    {
        private readonly Func<INavigation> _navigationProvider;

        public NavigationProvider(Func<INavigation> navigationProvider)
        {
            if (navigationProvider == null)
                throw new ArgumentNullException(nameof(navigationProvider));

            _navigationProvider = navigationProvider;
        }

        public INavigation GetNavigation()
        {
            return _navigationProvider();
        }
    }
}