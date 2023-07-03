using System;
using System.Collections.Generic;
using System.ComponentModel;
using UndoAssessment.Models;
using UndoAssessment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UndoAssessment.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}