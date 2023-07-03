using System;
using System.Collections.Generic;
using UndoAssessment.ViewModels;
using UndoAssessment.Views;
using Xamarin.Forms;

namespace UndoAssessment
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AssesmentPage), typeof(AssesmentPage));
            Routing.RegisterRoute(nameof(AssesmentResultPage), typeof(AssesmentResultPage));
            Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
