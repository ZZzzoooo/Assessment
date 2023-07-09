using UndoAssessment.Domain.Navigation.Types;

namespace UndoAssessment.Domain.Navigation.Builders
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly TypeResolver _typeResolver;

        public ViewModelBuilder(TypeResolver typeResolver)
        {
            _typeResolver = typeResolver;
        }

        public object BuildViewModel(string tag)
        {
            return _typeResolver.ResolveNamed<ViewModelAbstract>(tag);
        }
    }
}