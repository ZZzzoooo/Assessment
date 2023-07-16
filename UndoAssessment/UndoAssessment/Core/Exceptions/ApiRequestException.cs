using System;

namespace UndoAssessment.Services
{
    public class ApiRequestException : Exception
    {
        public ApiRequestException(string message) : base(message)
        {
        }
    }
}
