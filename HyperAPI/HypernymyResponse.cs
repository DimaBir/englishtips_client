using System.Collections.Generic;
using Newtonsoft.Json;

namespace HyperAPI
{
    class HypernymyResponse
    {
        [JsonProperty("result")]
        public IList<string> Hypernymies { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
