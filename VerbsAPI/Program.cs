using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace VerbsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check =
                "Ran run run run throw sit eat\n\n\n";

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to check for verbs"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://avrl.cs.technion.ac.il:80/api/verbs2";

            // Sends created json to the server:
            // returns: Dictionary - that contains verbs and their indexes in sended text:
            //      string = verb itself,
            //      List<int> - list of indexes of verb in the text
            List<VerbsResponse> response =
                GenericSender<List<VerbsResponse>>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to find verbs...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (VerbsResponse verbObject in response)
            {
                Console.Write($"Verb: '{verbObject.Verb}' - Length: {verbObject.VerbLength} - Index: ");
                foreach (int index in verbObject.Indexes)
                    Console.Write($"{index}, ");

                Console.WriteLine();
            }


            sw.Stop();
            Console.WriteLine("\n\nTime Elapsed={0}", sw.Elapsed);
            return;
        }
    }
}
