using Newtonsoft.Json;

namespace SentenceStructureAPI
{
    public class SentenceStructureResponse
    {
        [JsonProperty("result")]
        public string Structure { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
