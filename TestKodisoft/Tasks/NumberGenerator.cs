using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Task5.Interfaces;

namespace Task5
{
    class NumberGenerator : INumberGenerator
    {
        private string apiUrl = "https://api.random.org/json-rpc/1/invoke";
        private string apiKey = "9f3b6079-685f-40ee-83bc-e7468a7a9a55";

        //Generator of random number sequence
        public async Task<Queue<int>> GetNumberSequenceAsync(int quantity)
        {
            Queue<int> localQueue = new Queue<int>();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(this.apiUrl);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"jsonrpc\":\"2.0\",\"method\":\"generateIntegers\",\"params\":{\"apiKey\":\"" + this.apiKey + "\",\"n\":" + quantity + ",\"min\":0,\"max\":1e9,\"replacement\":true,\"base\":10},\"id\":1957}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    localQueue = parseGeneratorJsonResponse(result, quantity);
                }
            }
            return localQueue;
        }

        private Queue<int> parseGeneratorJsonResponse(string json, int quantity)
        {
            Queue<int> temporaryQueue = new Queue<int>();
            dynamic dynObj = JsonConvert.DeserializeObject<object>(json);
            if (dynObj.result != null)
            {
                for (int i = 0; i < dynObj.result.random.data.Count; i++)
                {
                    temporaryQueue.Enqueue((int)dynObj.result.random.data[i]);
                }
            }
            else
            {
                temporaryQueue = this.GetRandomNumbersUsingBCL(quantity);
            }
            return temporaryQueue;
        }
 
        //BCL`s generator
        public Queue<int> GetRandomNumbersUsingBCL(int quantity)
        {
            Queue<int> temporaryQueue = new Queue<int>();

            Random rand = new Random();
            for (int i = 0; i < quantity; i++)
            {
                temporaryQueue.Enqueue(rand.Next());
            }
            return temporaryQueue;
        }
    }
}
