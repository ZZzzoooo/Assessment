using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UndoAssessment.Models;
using UndoAssessment.ViewModels;

namespace UndoAssessment.Views
{
    public partial class UserFormPage : ContentPage
    {
        public Item Item { get; set; }

        public UserFormPage()
        {
            InitializeComponent();
            BindingContext = new UserFormViewModel();
        }
    }
}
