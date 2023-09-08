using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.Models
{
    public class ResponseModel
    {
        public int errorCode { get; set; }
        public string message { get; set; }
        public string date { get; set; }
        public bool isSuccess { get; set; }
    }
}
