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

            // Sends created json to server and returns:  on success - response object that we have created, exception -  on failure
            EnglishTipsResponse response = exampleSender.Send(json, "https://avrl.cs.technion.ac.il:80/api/test");

            Console.WriteLine($"Say Aloud the: {response.Text}");

            foreach (int index in response.Indexes)
                Console.WriteLine($"Index: {index}");

            // Lets try to say the text from response.
            SayAloud.Say(text: response.Text);
        }
    }
}
