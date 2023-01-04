using Newtonsoft.Json;
using System.Text;

namespace LayeredExample.DataAccessLayer
{
    internal class OpenAIClient
    {
        private string apiKey;

        public OpenAIClient(string apiKey) => this.apiKey = apiKey;

        public string Model { get; set; }
        public double Temperature { get; set; }

        public async Task<string> Completion(string prompt)
        {
         //   string model = "text-davinci-002";
            int maxTokens = 1024;
            //float temperature = 0.5f;

            // Build the API request
            string requestUrl = $"https://api.openai.com/v1/completions";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var requestJson = new
            {
                prompt = prompt,
                max_tokens = maxTokens,
                temperature = Temperature,
                model = Model
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(requestJson), Encoding.UTF8, "application/json");

            // Send the request and receive the response
            HttpResponseMessage response = client.PostAsync(requestUrl, content).Result;
            string responseJson = response.Content.ReadAsStringAsync().Result;

            // Extract the completed text from the response
            dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
            string completedText = responseObject.choices[0].text;

            return await Task<string>.FromResult(completedText);
        }
    }
}