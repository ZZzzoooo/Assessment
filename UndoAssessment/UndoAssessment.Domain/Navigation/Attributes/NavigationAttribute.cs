using System;

namespace UndoAssessment.Domain.Navigation.Attributes
{
    public class NavigationAttribute : Attribute
    {
        public string NavigationTag { get; set; }
    }
}