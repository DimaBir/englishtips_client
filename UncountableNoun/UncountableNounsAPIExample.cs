using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace UncountableNoun
{
    public static class UncountableNounsAPIExample
    {
        public static void Send()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check =
                "Vegetations is not very good but Underwears is better";


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://avrl.cs.technion.ac.il:80/api/uncountable";

            List<UncountableNounResponse> response =
                GenericSender<List<UncountableNounResponse>>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to find uncountable nouns...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (UncountableNounResponse uncountableNoun in response)
            {
                Console.Write($"Uncountable Noun: '{uncountableNoun.UncountableNoun}' - Length: {uncountableNoun.Length} - Index: ");
                foreach (int index in uncountableNoun.Indexes)
                    Console.Write($"{index}, ");

                Console.WriteLine();
            }


            sw.Stop();
            Console.WriteLine("\n\nTime Elapsed={0}", sw.Elapsed);
            return;
        }
    }
}
