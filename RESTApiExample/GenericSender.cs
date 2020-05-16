using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace RESTApiExample
{
    /// <summary>
    /// Static class no need to implement, using as namespace
    /// </summary>
    /// <typeparam name="T">JSON Object class that match JSON response body.</typeparam>
    public static class GenericSender<T>
    {
        /// <summary>
        /// Sends JSON to server.
        ///
        /// Here working example;
        /// <example>
        ///     string api = "http://127.0.0.1:5000/api/verbs";
        ///     Dictionary<string, List<int>> response = GenericSender<Dictionary<string, List<int>>>.Send(json: json, api: api, method: "POST");
        /// </example>
        /// </summary>
        /// <param name="json">JSON string to send</param>
        /// <param name="api">Absolute path of API as string</param>
        /// <param name="method">"POST"/"GET" method, we will talk about difference in the future.</param>
        /// <returns>T generic class that represents response as JSON object.</returns>
        public static T Send(string json, string api, string method)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Reads responds and returns them, we expect here only one response so we will return it, but if there will be more
            // in the future we can use List<string>
            T responseJsonObject;
            try
            {
                Uri uri = new Uri(api);
                // Creates request to specific API (/api/test), full path needed.
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
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


                // Statemnt with ?? called Nullable it checks if httpResponse.GetResponseStream() is not Null, if it is null we will throw exception, else we will continue
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    string response = streamReader.ReadToEnd();
                    if (response.StartsWith("Error"))
                    {
                        throw new InvalidOperationException(response);
                    }
                    // Here we pass our class as template that expected to be deserialized from response stream
                    responseJsonObject = JsonConvert.DeserializeObject<T>(response);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"An exception occured: {e.Message}");
                throw;
            }
            // Just to be more informative if server returned 200 (OK) status but no text (maybe some logic error om server side) we will
            // return proper message instead of server crash
            return responseJsonObject;
        }
    }
}
