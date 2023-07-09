using System.Collections.Generic;
using UndoAssessment.Common.Navigation;
using UndoAssessment.Domain;
using Xamarin.Forms;

namespace UndoAssessment.View
{
    public class BasePage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is INavigated nav)
                nav.NavigatedAsync(new NavigationData(new Dictionary<string, object>()));
        }
    }
}