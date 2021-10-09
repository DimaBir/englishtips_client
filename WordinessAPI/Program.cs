using System;
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

            // Prepare request parameters
            string text_to_check =
                "There are many students who like reading. It is the desk that is uncomfortable.\n\n\n";


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "http://164.90.160.20/api/wordiness";


            // Send request
            WordinessResponse response =
                GenericSender<WordinessResponse>.Send(json, api: api, "POST");

            // Print out the response.
            Console.WriteLine($"Sending text to '{api}' to find wordiness...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            foreach (WordinessResponse.WordinessData match in response.Results)
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

            // Print time elapsed.
            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
