using System;

namespace UndoAssessment.Domain.Navigation.Types
{
    public class NavigationTypeRegistration
    {
        public Type Type { get; }

        public string Tag { get; }

        public NavigationTypeRegistration(Type type, string tag)
        {
            Type = type;
            Tag = tag;
        }
    }
}