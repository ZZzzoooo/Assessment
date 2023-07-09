namespace UndoAssessment.Domain.Navigation.Builders
{
    public interface IViewModelBuilder
    {
        object BuildViewModel(string tag);
    }
}