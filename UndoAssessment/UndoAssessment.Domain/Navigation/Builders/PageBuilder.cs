using UndoAssessment.Domain.Navigation.Types;
using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation.Builders
{
    public class PageBuilder : IPageBuilder
    {
        private readonly TypeResolver _typeResolver;

        public PageBuilder(TypeResolver typeResolver)
        {
            _typeResolver = typeResolver;
        }

        public Page BuildPage(string tag)
        {
            return _typeResolver.ResolveNamed<Page>(tag);
        }
    }
}