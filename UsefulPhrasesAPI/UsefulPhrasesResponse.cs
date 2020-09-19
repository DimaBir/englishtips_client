using System.Collections.Generic;
using Newtonsoft.Json;

namespace UsefulPhrasesAPI
{
    class UsefulPhrasesResponse
    {
        [JsonProperty("keys")]
        public IList<string> Phrases { get; set; }
        [JsonProperty("examples")]
        public IList<string> Examples { get; set; }
    }
}
