using Xamarin.Forms;

namespace UndoAssessment.Domain.Navigation.Builders
{
    public interface IPageBuilder
    {
        Page BuildPage(string tag);
    }
}