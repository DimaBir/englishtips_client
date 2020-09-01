using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfusedWordsAPI
{
    public class ConfusedWordsResponse
    {
        [JsonProperty("result")]
        public string Note { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
