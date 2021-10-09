using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace TextSummarizationAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Prepare request parameters
            string text_to_check =
                "There are many techniques available to generate extractive summarization to keep it simple," +
                " I will be using an unsupervised learning approach to find the sentences similarity and rank them." +
                " Summarization can be defined as a task of producing a concise and fluent summary while preserving" +
                " key information and overall meaning. One benefit of this will be, you don’t need to train and build" +
                " a model prior start using it for your project. It’s good to understand Cosine similarity to make" +
                " the best use of the code you are going to see. Cosine similarity is a measure of similarity between" +
                " two non-zero vectors of an inner product space that measures the cosine of the angle between them." +
                " Its measures cosine of the angle between vectors. The angle will be 0 if sentences are similar.";


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "http://164.90.160.20/api/summ";

            // Send request
            TextSummarizationResponse response =
                GenericSender<TextSummarizationResponse>.Send(json, api: api, "POST");

            // Print out the response.
            Console.WriteLine($"Sending text to '{api}'...\n\n\n");
            Console.WriteLine($"The text: \n {text_to_check}\n");

            Console.Write($"The summary: \n'{response.Summary}'");

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
