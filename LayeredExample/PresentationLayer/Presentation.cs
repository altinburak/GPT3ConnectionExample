using LayeredExample.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredExample.PresentationLayer
{
    public class Presentation : IPresentation
    {
        private readonly IBusinessLogic _businessLogic;

        public Presentation(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void ShowData(string data)
        {
            // Display the data to the user
            //Console.WriteLine($"Displaying data: {data}");

            // Process the data using the business logic layer
            _businessLogic.ProcessData(data);
        }
    }
}
