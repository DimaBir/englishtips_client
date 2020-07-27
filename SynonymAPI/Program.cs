using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace SynonymAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string word_to_check = "   Dog  ";

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "https://englishtips.azurewebsites.net/api/syn";
            //string api = "http://127.0.0.1:5000//api/syn";

            // Sends request json to the server:
            // Response: List<string> - list of synonyms 
            SynonymResponse response =
                GenericSender<SynonymResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{word_to_check}\" to '{api}' to find synonyms...\n\n\n");
            
            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Original word: {word_to_check} \n\nSynonyms: \n");

                // Print out synonyms
                foreach (string synonym in response.Synonyms)
                    Console.WriteLine($"{synonym}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
