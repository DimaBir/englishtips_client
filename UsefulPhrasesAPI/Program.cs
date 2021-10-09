using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace UsefulPhrasesAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string api = "http://164.90.160.20/api/useful";

            // You get response as a list of keys and a list of values separately, pay attention: 
            // as a json send NULL, and as a method GET method
            UsefulPhrasesResponse response =
                GenericSender<UsefulPhrasesResponse>.Send(null, api: api, "GET");

            // Create dictionary to hold response lists
            Dictionary<string, string> usefulPhrases = new Dictionary<string, string>();
            for (int i = 0; i < response.Phrases.Count; i++)
                usefulPhrases.Add(response.Phrases[i], response.Examples[i]);

            // Read dictionary values
            foreach (KeyValuePair<string, string> usefulPhrase in usefulPhrases)
                Console.WriteLine("Phrase: {0}\n Examples: \n{1}", usefulPhrase.Key, usefulPhrase.Value);

            sw.Stop();
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
