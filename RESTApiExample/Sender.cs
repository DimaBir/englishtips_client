using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace RESTApiExample
{
    class Sender
    {
        public EnglishTipsResponse Send(string json, string api)
        {
            // Creates request to specific API (/api/test), full path needed.
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(api);
            // Tells to Client what type of request to send, we are sending json, so 'application/json'
            httpWebRequest.ContentType = "application/json";

            // Method POST we want send something to server. GET we want get something from server
            httpWebRequest.Method = "POST";

            // Writes json to request stream, we can send more than one request, also sending can be asynchronous (in the future)
            // Here using is necessary. readers/writers are open stream, that consumes memory. Stream need to be closed, else memory leak, 
            // if we use using, it will close automatically, when we leave {} block. 
            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            // Sends our requests to server, and gets response, if there any error - exception will be thrown here.
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            
            // Just reads respons and returns them, we expect here only one response so we will return it, but if there will be more
            // in the future we can use List<string>
            EnglishTipsResponse responseJsonObject;

            // Statemnt with ?? called Nullable it checks if httpResponse.GetResponseStream() is not Null, if it is null we will throw exception, else we will continue
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                string response = streamReader.ReadToEnd();

                // Here we pass our class as template that expected to be deserialized from response stream
                responseJsonObject = JsonConvert.DeserializeObject<EnglishTipsResponse>(response);
            }

            // Just to be more informative if server returned 200 (OK) status but no text (maybe some logic error om server side) we will
            // return proper message instead of server crash
            return responseJsonObject;
        }
    }
}
