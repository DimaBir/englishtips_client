using Newtonsoft.Json;

namespace DictionaryAPI
{
    public class DictionaryResponse
    {
        [JsonProperty("result")]
        public string Definition { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
