using System;
namespace UndoAssessment.Models
{
	public class FailureResponse
	{
        public int errorCode { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }
}