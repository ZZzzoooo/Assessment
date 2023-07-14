using System;
using Newtonsoft.Json;

namespace UndoAssessment.Contracts;

public class FailResponse
{
	[JsonProperty("errorCode")]
	public int ErrorCode { get; set; }
	[JsonProperty("message")]
	public string Message { get; set; }
	[JsonProperty("date")]
	public DateTime Date { get; set; }
}