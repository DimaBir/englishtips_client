using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTApiExample
{
    public class EnglishTipsResponse
    {
        public string Text { get; set; }
        public List<int> Indexes { get; set; }
    }
}
