using System;
using System.Collections.Generic;
using System.Linq;
using UndoAssessment.Domain.Navigation.Attributes;

namespace UndoAssessment.Domain.Navigation.Types
{
    public class RegisteredNavigationTypesProvider
    {
        public IEnumerable<NavigationTypeRegistration> GetRegistrations<TAttribute>(string assembly)
            where TAttribute : NavigationAttribute
        {
            var allTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .First(a => a.FullName.Contains(assembly))
                .GetTypes();
            var navigationTypes = allTypes
                .Where(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(TAttribute)))
                .ToList();

            foreach (var type in navigationTypes)
            {
                var attributes = type.GetCustomAttributes(typeof(TAttribute), false);
                var attribute = attributes.First() as TAttribute;
                yield return new NavigationTypeRegistration(type, attribute.NavigationTag);
            }
        }
    }
}