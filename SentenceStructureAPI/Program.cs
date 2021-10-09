using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace SentenceStructureAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string word_to_check = "   moreover  ";

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "http://164.90.160.20/api/sentence_structure";
            //string api = "http://127.0.0.1:5000/api/hypon";


            SentenceStructureResponse response =
                GenericSender<SentenceStructureResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{word_to_check}\" to '{api}'...\n\n\n");

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Input word: {word_to_check} \n");

                // Print out 
                Console.WriteLine($"{response.Structure}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
