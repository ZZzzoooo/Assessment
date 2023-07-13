using Newtonsoft.Json;

namespace UndoAssessment.Models.Data
{
    public class FailureModel: BaseDataModel
    {
        [JsonProperty("errorCode")]
        public int ErrorCode { get; set; }
    }
}
