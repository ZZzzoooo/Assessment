using System;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation
{
    public class AppProvider
    {
        private readonly Func<Application> _navigationProvider;

        public AppProvider(Func<Application> navigationProvider)
        {
            if (navigationProvider == null)
                throw new ArgumentNullException(nameof(navigationProvider));

            _navigationProvider = navigationProvider;
        }

        public Application GetApplication()
        {
            return _navigationProvider();
        }
    }
}