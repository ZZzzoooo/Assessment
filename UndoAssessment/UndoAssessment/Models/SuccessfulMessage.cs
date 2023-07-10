using Newtonsoft.Json;
using System;

namespace UndoAssessment.Models
{
    public class SuccessfulMessage
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }


}
