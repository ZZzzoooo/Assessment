using System.Collections.Generic;
using System.Threading.Tasks;

namespace UndoAssessment.Common.Navigation
{
    public interface INavigationService
    {
        Task NavigateWithReplaceAsync(string tag, params KeyValuePair<string, object>[] parameters);
        Task NavigateAsync(string tag, params KeyValuePair<string, object>[] parameters);
        Task NavigateBackAsync(params KeyValuePair<string, object>[] parameters);
    }
}