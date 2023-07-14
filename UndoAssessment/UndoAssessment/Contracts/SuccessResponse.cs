using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace UndoAssessment.Contracts;

public class SuccessResponse
{
	[JsonProperty("message")]
	public string Message { get; set; }
	[JsonProperty("date")]
	public DateTime Date { get; set; }
}