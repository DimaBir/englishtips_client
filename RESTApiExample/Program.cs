using System;
using System.Web.Script.Serialization;

namespace RESTApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instance fo Sender class that have 1 method that send json to server
            Sender exampleSender = new Sender();

            // Create some sutom json, fields are mandatory
            string json = new JavaScriptSerializer().Serialize(new
            {
                name = "Yosy",
                age = 75
            });

            // Sends created json to server and returns response on success, exception on failure
            string response = exampleSender.Send(json);
            Console.WriteLine(response);
        }
    }
}
