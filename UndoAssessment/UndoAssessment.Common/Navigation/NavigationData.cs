using System.Collections.Generic;

namespace UndoAssessment.Common.Navigation
{
    public class NavigationData
    {
        public IDictionary<string, object> Parameters { get; }

        public NavigationData(IDictionary<string, object> parameters)
        {
            Parameters = parameters;
        }
    }
}