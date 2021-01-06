using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionUITests.PageObjectModel
{
    public class AcceptedPage : Page
    {

        public string AcceptedMessage 
        {
            get 
            {
                return Find.Element(By.Id("acceptedMessage")).Text;
            } 
        }
    }
}
