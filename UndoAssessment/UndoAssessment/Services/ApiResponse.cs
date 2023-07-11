using System;

namespace UndoAssessment.Services
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public ApiResponseModel Result { get; set; }
    }

    public class ApiResponseModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Message: {Message}, date: {Date}";
        }
    }
}
