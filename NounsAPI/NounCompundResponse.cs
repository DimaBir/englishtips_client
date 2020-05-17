using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NounsAPI
{
    public class NounCompoundResponse
    {
        [JsonProperty("result")]
        public List<List<int>> Result { get; set; }
        public float ServerExecutionTime { get; set; }
    }
}
