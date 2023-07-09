using System.Threading.Tasks;
using UndoAssessment.Common.Navigation;

namespace UndoAssessment.Domain
{
    public interface INavigated
    {
        Task NavigatedAsync(NavigationData data);
    }
}