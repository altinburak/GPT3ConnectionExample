using LayeredExample.DataAccessLayer;

namespace LayeredExample.BusinessLayer
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IChatbot _chatbot;

        public BusinessLogic(IChatbot chatbot)
        {
            _chatbot = chatbot;
        }

        public void ProcessData(string data)
        {
            // Use the chatbot to generate a response
            string response = _chatbot.GetResponse(data).Result;

            // Do something with the response (e.g., display it to the user)
            Console.WriteLine($"Chatbot response: {response}");
        }
    }
}
