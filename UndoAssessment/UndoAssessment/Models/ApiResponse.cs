using System;

namespace UndoAssessment.Models
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int ErrorCode { get; set; }
    }
}