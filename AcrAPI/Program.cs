using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace AcrAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string word_to_check = "   USA  ";

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "https://avrl.cs.technion.ac.il:80/api/acr";
            //string api = "http://127.0.0.1:5000/api/acr";


            AcronymResponse response =
                GenericSender<AcronymResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{word_to_check}\" to '{api}' to find acronym...\n\n\n");

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Input word: {word_to_check} \n");

                // Print out
                Console.WriteLine($"Acronym: {response.Acronym};\nDefinition: {response.Definition}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}