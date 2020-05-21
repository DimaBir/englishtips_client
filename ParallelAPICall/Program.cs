using System;
using System.Diagnostics;
using System.Threading;
using GoogleTranslateAPI;
using NounsAPI;
using SynonymAPI;
using TopWordsAPI;
using UncountableNoun;
using VerbsAPI;

namespace ParallelAPICall
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Creating and initializing threads  
            Thread thread1 = new Thread(NounsAPIExample.Send);

            Thread thread2 = new Thread(TopTenWordsAPIExample.Send);

            Thread thread3 = new Thread(SynonymAPIExample.Send);

            Thread thread4 = new Thread(VerbsAPIExamlpe.Send);

            Thread thread5 = new Thread(UncountableNounsAPIExample.Send);

            Thread thread6 = new Thread(GoogleTranslateAPIExample.Send);

            // Start threads
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();


            // Join thread 
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
            thread6.Join();

            sw.Stop();
            Console.WriteLine("\n\nTotal Time = {0} (sec)", sw.Elapsed);
        }
    }
}
