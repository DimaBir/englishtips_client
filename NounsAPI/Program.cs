using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace NounsAPI
{
    public static class Program
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


            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "https://avrl.cs.technion.ac.il:80/api/noun-compound";


            NounCompoundResponse response =
                GenericSender<NounCompoundResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending text to '{api}' to find noun-compounds...\n\n\n");
            Console.WriteLine($"Original text: {text_to_check}");

            // Print out verbs.
            foreach (List<int> compoundIndexes in response.Result)
            {
                int startIndex = compoundIndexes[0];
                int length = compoundIndexes[1];
                String nounCompound = text_to_check.Substring(startIndex, length+1); // PAY ATTEMTION ADDED 1 MANUALLY TO LENGTH IN ORDER TO PRINT WHOLE WORD

                Console.WriteLine($"Noun Compound: '{nounCompound}' || Start at: {startIndex} || Length: {length}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
