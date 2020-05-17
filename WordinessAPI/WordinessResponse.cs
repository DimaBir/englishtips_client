using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordinessAPI
{
    public class WordinessResponse
    {
        [JsonProperty("Result")]
        public IList<WordinessDate> Results { get; set; }
        [JsonProperty("ServerExecutionTime")]
        public float ServerExecutionTime { get; set; }

        public class WordinessDate
        {
            public string Wordiness { get; set; }
            public int Length { get; set; }
            public IList<int> Indexes { get; set; }
            public string Hint { get; set; }
        }
    }
}
