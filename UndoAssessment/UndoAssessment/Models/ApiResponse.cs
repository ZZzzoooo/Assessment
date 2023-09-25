using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.Models
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int? ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
