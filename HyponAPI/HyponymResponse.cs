using System.Collections.Generic;
using Newtonsoft.Json;

namespace HyponAPI
{
    public class HyponymResponse
    {
        [JsonProperty("result")]
        public IList<string> Hyponyms { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
