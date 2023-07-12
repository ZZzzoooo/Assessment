using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.Models
{
    public class ErrorResult
    {
        public int? errorCode { get; set; }
        public string message { get; set; }
        public DateTime? date { get; set; }
    }
}
