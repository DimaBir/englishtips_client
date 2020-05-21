using System;
using System.Diagnostics;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace TopWordsAPI
{
    public static class TopTenWordsAPIExample
    {
        public static void Send()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Prepare request parameters
            string text_to_check =
                "In publishing and graphic design, Lorem ipsum is a placeholder text" +
                " commonly used to demonstrate the visual form of a document or a typeface" +
                " without relying on meaningful content. Lorem ipsum may be used before" +
                " final copy is available, but it may also be used to temporarily replace" +
                " copy in a process called greeking, which allows designers to consider" +
                " form without the meaning of the text influencing the design.\n\n\n";


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "https://englishtips.azurewebsites.net/api/topwords";


            // Send request
            TopWordsResponse response =
                GenericSender<TopWordsResponse>.Send(json, api: api, "POST");

            // Print out the response.
            Console.WriteLine($"Sending text to '{api}' to find wordiness...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            foreach (TopWordsResponse.TopWordsData match in response.Results)
            {
                Console.Write($"Word: '{match.Word}' Length: {match.Length} Indexes: ");
                foreach (int index in match.Indexes)
                {
                    Console.Write($"{index}, ");
                }
                Console.WriteLine();
                Console.WriteLine($"Place: {match.Place}");
            }

            // Print time elapsed.
            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
