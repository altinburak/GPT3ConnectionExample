//using Newtonsoft.Json;
//using System;
//using System.Net.Http;
//using System.Text;

//namespace GPT_3_Connection
//{
//    internal class Program
//    {



//        //static void Main(string[] args)
//        //{
//        //    Console.WriteLine("Enter a prompt:");
//        //    string prompt = Console.ReadLine();

//        //    string apiKey = "sk-lbablablablablba";
//        //    string model = "text-davinci-002";
//        //    int maxTokens = 1024;
//        //    float temperature = 0.5f;

//        //    // Build the API request
//        //    string requestUrl = $"https://api.openai.com/v1/completions";
//        //    HttpClient client = new HttpClient();
//        //    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

//        //    var requestJson = new
//        //    {
//        //        prompt = prompt,
//        //        max_tokens = maxTokens,
//        //        temperature = temperature,
//        //        model = model
//        //    };

//        //    StringContent content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");

//        //    // Send the request and receive the response
//        //    HttpResponseMessage response = client.PostAsync(requestUrl, content).Result;
//        //    string responseJson = response.Content.ReadAsStringAsync().Result;

//        //    // Extract the completed text from the response
//        //    dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
//        //    string completedText = responseObject.choices[0].text;

//        //    Console.WriteLine("Completed text: " + completedText);

//        //}
//    }
//}

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "sk-blablabblba";
        string prompt = "Once upon a time";

        string response = await CreateChat(apiKey, prompt);
        Console.WriteLine("ChatGPT Response:");
        Console.WriteLine(response);
    }

    static async Task<string> CreateChat(string apiKey, string prompt)
    {
        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            var requestData = new
            {
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                },
                prompt = prompt,
                max_tokens = 1024,
                temperature = 0.5f,
                model = "text-davinci-002"
            };

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            

            var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API request failed: {responseContent}");
            }

            return responseContent;
        }
    }
}


