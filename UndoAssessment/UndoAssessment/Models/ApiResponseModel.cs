using System;
using Newtonsoft.Json;

namespace UndoAssessment.Models
{
    public class ApiResponseModel
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

}

