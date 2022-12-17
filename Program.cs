using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace GPT_3_Connection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a prompt:");
            string prompt = Console.ReadLine();

            string apiKey = "Your API Key";
            string model = "text-davinci-002";
            int maxTokens = 1024;
            float temperature = 0.5f;

            // Build the API request
            string requestUrl = $"https://api.openai.com/v1/completions";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestJson = new
            {
                prompt = prompt,
                max_tokens = maxTokens,
                temperature = temperature,
                model = model
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");

            // Send the request and receive the response
            HttpResponseMessage response = client.PostAsync(requestUrl, content).Result;
            string responseJson = response.Content.ReadAsStringAsync().Result;

            // Extract the completed text from the response
            dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
            string completedText = responseObject.choices[0].text;

            Console.WriteLine("Completed text: " + completedText);

        }
    }
}
