using System.Collections.Generic;
using Newtonsoft.Json;

namespace SynonymAPI
{
    public class SynonymResponse
    {
        [JsonProperty("result")]
        public IList<string> Synonyms { get; set; }
        public float ServerExecutionTime { get; set; }
        [JsonProperty("Error")]
        public string ErrorMessage { get; set; }
    }
}
