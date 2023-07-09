using System;

namespace UndoAssessment.Common.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int ErrorCode { get; set; }

        public override string ToString()
        {
            var errorLine = ErrorCode > 0 ? $"ErrorCode: {ErrorCode}" : "";
            return
                $"Message: {Message}\n" +
                $"Date: {Date.ToString()}\n" +
                errorLine;
                
        }
    }
}