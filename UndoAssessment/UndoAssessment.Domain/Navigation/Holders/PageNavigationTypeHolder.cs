using System;
using System.Collections.Generic;
using System.Linq;
using UndoAssessment.Domain.Navigation.Types;

namespace UndoAssessment.Domain.Navigation.Holders
{
    public class PageNavigationTypeHolder
    {
        private readonly IEnumerable<NavigationTypeRegistration> _registrations;

        public PageNavigationTypeHolder(IEnumerable<NavigationTypeRegistration> registrations)
        {
            _registrations = registrations;
        }

        public NavigationTypeRegistration GetPageTypeRegistration(string tag)
            => _registrations.FirstOrDefault(r => r.Tag == tag);

        public NavigationTypeRegistration GetPageTypeRegistration(Type type)
            => _registrations.FirstOrDefault(r => r.Type == type);
    }
}