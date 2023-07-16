using System.Linq;

namespace UndoAssessment.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsNameValid(string name)
        {
            // For example, check for illegal characters or minimum length
            return !string.IsNullOrWhiteSpace(name);
        }

        public static bool IsAgeValid(string age)
        {
            // For example, check if it's a numeric value or within a certain range
            return int.TryParse(age, out _) && !string.IsNullOrWhiteSpace(age);
        }
    }
}
