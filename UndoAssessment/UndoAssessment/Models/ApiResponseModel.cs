using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.Models
{
    public class ApiResponseModel
    {
        public string message { get; set; }
        public string date { get; set; }
        public int errorCode { get; set; }

        public bool IsSuccess
        {
            get
            {
                return errorCode == 0;
            }
        }

    }
}
