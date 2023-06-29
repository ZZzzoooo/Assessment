using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UndoAssessment.Models;
using UndoAssessment.Views;
using UndoAssessment.ViewModels;

namespace UndoAssessment.Views
{
    public partial class TestPage : ContentPage
    {
        TestViewModel _viewModel;

        public TestPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TestViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
