using Newtonsoft.Json;
using System;

namespace UndoAssessment.Models
{
    public class FailedMessage
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }


}
