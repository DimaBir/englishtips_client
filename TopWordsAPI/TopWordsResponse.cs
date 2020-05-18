using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopWordsAPI
{
    class TopWordsResponse
    {
        [JsonProperty("Result")]
        public IList<TopWordsData> Results { get; set; }
        [JsonProperty("ServerExecutionTime")]
        public float ServerExecutionTime { get; set; }

        public class TopWordsData
        {
            public string Word { get; set; }
            public int Length { get; set; }
            public IList<int> Indexes { get; set; }
            public int Place { get; set; }
        }
    }
}
