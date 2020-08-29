using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace GoogleTranslateAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_translate = "Hello, how are you? Enter here text and the language you want to translate into.";
            string destination_language = Languages.PORTUGUESE;
            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to send to server"
            // "language": (string)"he"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_translate,
                language = destination_language
            });

            string api = "https://avrl.cs.technion.ac.il:80/api/translate";

            // Sends created json to server and returns:
            // returns: string
            string translation = GenericSender<string>.Send(json, api: api, "POST");
            Console.WriteLine($"Sending text to '{api}' to translate to hebrew...\n\n\n");
            Console.WriteLine($"Original text: {text_to_translate}");

            // Technique to handle  with printing hebrew to console.
            // If you will look at the string itself on debug mode, you will see that it stored as legal hebrew,
            // only in printing its messed up, so here is the solution.
            // Maybe in the word addin you can print hebrew as is, cause this solution reverses chars and numbers too. 
            if (destination_language == Languages.HEBREW)
            {
                Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
                Console.WriteLine($"Translated: {new string(translation.Reverse().ToArray())}");
            }
            else
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Translated: {translation}");
            }

            sw.Stop();
            Console.WriteLine("\n\nTime Elapsed={0}", sw.Elapsed);
            return;
        }
    }
}
