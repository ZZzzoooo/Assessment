using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UndoAssessment.Models
{
    public class ResponseModel
    {
        [JsonProperty("errorcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
