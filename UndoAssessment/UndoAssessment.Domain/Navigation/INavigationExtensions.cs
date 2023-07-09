using System.Linq;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation
{
    public static class INavigationExtensions
    {
        public static Page CurrentPage(this INavigation navigation)
            => navigation.NavigationStack.LastOrDefault();
    }
}