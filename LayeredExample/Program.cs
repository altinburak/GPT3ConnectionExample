// Replace YOUR_API_KEY with your actual API key
using LayeredExample.BusinessLayer;
using LayeredExample.DataAccessLayer;
using LayeredExample.PresentationLayer;



string apiKey = "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";

// Create an instance of the chatbot layer
IChatbot chatbot = new Chatbot(apiKey);

// Create an instance of the business logic layer, injecting the chatbot layer
IBusinessLogic businessLogic = new BusinessLogic(chatbot);

// Create an instance of the presentation layer, injecting the business logic layer
IPresentation presentation = new Presentation(businessLogic);


Console.WriteLine("Enter a prompt(to finish type 'exit'):");
while (true)
{
    Console.Write("-> ");
    string prompt = Console.ReadLine();

    if (prompt == "exit")
    {
        break;
    }
    presentation.ShowData(prompt);
}


