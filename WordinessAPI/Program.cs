using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace WordinessAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check =
                "There are many students who like reading. It is the desk that is uncomfortable.\n\n\n";


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "https://englishtips.azurewebsites.net/api/wordiness";


            WordinessResponse response =
                GenericSender<WordinessResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to find wordiness...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (WordinessResponse.WordinessDate match in response.Results)
            {
                Console.Write($"Wordiness: '{match.Wordiness}' Length: {match.Length} Indexes: ");
                foreach (int index in match.Indexes)
                {
                    Console.Write($"{index}, ");
                }
                Console.WriteLine();
                Console.Write($"Hint: \n'{match.Hint}'\n\n\n");
                Console.WriteLine("=================================================");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
