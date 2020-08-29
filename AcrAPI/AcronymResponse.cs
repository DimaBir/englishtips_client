using Newtonsoft.Json;

namespace AcrAPI
{
    public class AcronymResponse
    {
        [JsonProperty("result")]
        public string Acronym { get; set; }
        [JsonProperty("definition")]
        public string Definition { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }

}
