using Newtonsoft.Json;

namespace TextSummarizationAPI
{
    public class TextSummarizationResponse
    {
        [JsonProperty("result")] 
        public string Summary { get; set; }
        public float ServerExecutionTime { get; set; }
    }
}
