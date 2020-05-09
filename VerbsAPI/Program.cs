using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using EnglishTips;

namespace VerbsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check =
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food." +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food.\n\n\n";

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to check for verbs"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/verbs";

            // Sends created json to server and returns:
            // returns: VerbsResponse - represents response object with two fields:
            //      string = verb itself,
            //      List<int> - list of indexes of verb in the text
            Dictionary<string, List<int>> response =
                GenericSender<Dictionary<string, List<int>>>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to translate to hebrew...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (KeyValuePair<string, List<int>> verb in response)
            {
                Console.Write($"Verb: '{verb.Key}' --- Index: ");
                foreach (int index in verb.Value)
                    Console.Write($"{index}, ");

                Console.WriteLine();
            }

            sw.Stop();
            Console.WriteLine("\n\nTime Elapsed={0}", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
