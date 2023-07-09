using System;
using System.Collections.Generic;
using System.Linq;
using UndoAssessment.Domain.Navigation.Types;

namespace UndoAssessment.Domain.Navigation.Holders
{
    public class ViewModelNavigationTypeHolder
    {
        private readonly IEnumerable<NavigationTypeRegistration> _registrations;

        public ViewModelNavigationTypeHolder(IEnumerable<NavigationTypeRegistration> registrations)
        {
            _registrations = registrations;
        }

        public NavigationTypeRegistration GetViewModelTypeRegistration(string tag)
            => _registrations.FirstOrDefault(r => r.Tag == tag);

        public NavigationTypeRegistration GetViewModelTypeRegistration(Type type)
            => _registrations.FirstOrDefault(r => r.Type == type);
    }
}