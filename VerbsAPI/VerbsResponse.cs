using System.Collections.Generic;

namespace VerbsAPI
{
    public class VerbsResponse
    {
        public string Verb { get; set; }
        public int VerbLength { get; set; }
        public List<int> Indexes { get; set; }
    }
}
