using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordinessAPI
{
    public class WordinessResponse
    {
        [JsonProperty("Result")]
        public IList<WordinessData> Results { get; set; }
        [JsonProperty("ServerExecutionTime")]
        public float ServerExecutionTime { get; set; }

        public class WordinessData
        {
            public string Wordiness { get; set; }
            public int Length { get; set; }
            public IList<int> Indexes { get; set; }
            public string Hint { get; set; }
        }
    }
}
