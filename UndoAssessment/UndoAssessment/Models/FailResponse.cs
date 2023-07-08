using System;

namespace UndoAssessment.Models
{
    public class FailResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
