using Newtonsoft.Json;

namespace UndoAssessment.Models.Data
{
    public class BaseDataModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }
}
