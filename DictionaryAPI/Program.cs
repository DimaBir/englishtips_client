using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace DictionaryAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string word_to_check = "   Irregardless   ";

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "http://164.90.160.20/api/dictionary";


            DictionaryResponse response =
                GenericSender<DictionaryResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{word_to_check}\" to '{api}' to find acronym...\n\n\n");

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                // Print out
                Console.WriteLine($"Definition: {response.Definition}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
