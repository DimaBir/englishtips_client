using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace NounsAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check =
                "Pack pack Six Ian has written a lot of work six-pack six-pack, has bitten a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of work, has bitten six-pack six-pack, six-pack a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of apples food apples food, has bitten a lot of apples , has eaten a lot of work apples. " +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of work apples, has bitten a lot of apples , has eaten a lot of food. " +
                "Ian has written a lot of work, has bitten a lot of apples , has eaten a lot of food.\n\n\n";

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to check for verbs"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/noun-compound";

            // Sends created json to the server:
            // returns: Dictionary - that contains verbs and their indexes in sended text:
            //      string = verb itself,
            //      List<int> - list of indexes of verb in the text
            NounCompoundResponse response =
                GenericSender<NounCompoundResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to find noun-compounds...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (List<int> compoundIndexes in response.Result)
            {
                String nounCompound = text_to_check.Substring(compoundIndexes[0], compoundIndexes[1] - compoundIndexes[0]);

                Console.Write($"Noun Compound: '{nounCompound}', Indexes: [ ");
                foreach (int index in compoundIndexes)
                    Console.Write($"{index}   ");
            
                Console.WriteLine(" ]");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
