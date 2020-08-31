using Newtonsoft.Json;

namespace AvgSenLenAPI
{
    class ASLResponse
    {
        [JsonProperty("result")]
        public string Average { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
