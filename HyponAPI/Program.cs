using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace HyponAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string word_to_check = "   Green  ";

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "https://avrl.cs.technion.ac.il:80/api/hypon";
            //string api = "http://127.0.0.1:5000/api/hypon";


            HyponymResponse response =
                GenericSender<HyponymResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{word_to_check}\" to '{api}' to find hyponym...\n\n\n");

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Input word: {word_to_check} \nHyponymies: \n");

                // Print out 
                foreach (string hyponymy in response.Hyponyms)
                    Console.WriteLine($"{hyponymy}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}