using System;
using Autofac;

namespace UndoAssessment.Domain.Navigation.Types
{
    public class TypeResolver
    {
        private Func<IContainer> _container;

        public TypeResolver(
            Func<IContainer> container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container().Resolve<T>();
        }

        public T ResolveNamed<T>(string name)
        {
            return _container().ResolveNamed<T>(name);
        }
    }
}