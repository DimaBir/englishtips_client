using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RESTApiExample;

namespace AvgSenLenAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string text_to_check = "Mind what no by kept. Celebrated no he decisively thoroughly. Our asked sex point her she seems. New plenty she horses parish design you. Stuff sight equal of my woody. Him children bringing goodness suitable she entirely put far daughter. ";

            // WARNING: the name of key is CHANGED! its text now 
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });

            string api = "http://164.90.160.20/api/asl";


            ASLResponse response =
                GenericSender<ASLResponse>.Send(json, api: api, "POST");

            Console.WriteLine($"Sending \"{text_to_check}\" to '{api}'...\n\n\n");

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
            }
            else
            {
                Console.WriteLine($"Input text: {text_to_check} \n");

                // Print out 
                Console.WriteLine($"Average Sentence Length: {response.Average}");
            }

            sw.Stop();
            Console.WriteLine("\n\nServer Execution Time = {0} (sec)", response.ServerExecutionTime);
            Console.WriteLine("Client Execution Time = {0} (sec)", sw.Elapsed);
            return;
        }
    }
}
