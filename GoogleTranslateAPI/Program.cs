using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using EnglishTips;
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

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to send to server"
            // "language": (string)"he"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_translate,
                language = Languages.HEBREW
            });

            string api = "https://englishtips.azurewebsites.net/api/translate";
            
            // Sends created json to server and returns:
            // returns: string
            string translation = GenericSender<string>.Send(json, api: api, "POST");
            Console.WriteLine($"Sending text to '{api}' to translate to hebrew...\n\n\n");
            Console.WriteLine($"Original text: {text_to_translate}");

            // Technique to handle  with printing hebrew to console.
            // If you will look at the string itself on debug mode, you will see that it stored as legal hebrew,
            // only in printing its messed up, so here is the solution.
            // Maybe in the word addin you can print hebrew as is, cause this solution reverses chars and numbers too. 
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");
            Console.WriteLine($"Translated: {new string(translation.Reverse().ToArray())}");
            
            
            sw.Stop();
            Console.WriteLine("\n\nTime Elapsed={0}", sw.Elapsed);
            Console.ReadKey();
            return;
        }
    }
}
