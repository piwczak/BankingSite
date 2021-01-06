using BankingSite.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.PageObjects;

namespace BankingSite.FunctionUITests.PageObjectModel
{
    public class LoanApplicationPage : Page<LoanApplication>
    {
        //public LoanApplicationPage EnterFirstName(string firstName)
        //{
        //    Find.Element(By.Id("FirstName")).SendKeys(firstName);

        //    return this;
        //}

        //public LoanApplicationPage EnterLastName(string lastName)
        //{
        //    Find.Element(By.Id("LastName")).SendKeys(lastName);

        //    return this;
        //}

        //public LoanApplicationPage EnterAge(string age)
        //{
        //    Find.Element(By.Id("Age")).SendKeys(age);

        //    return this;
        //}

        //public LoanApplicationPage EnterAnnualIncome(string income)
        //{
        //    Find.Element(By.Id("AnnualIncome")).SendKeys(income);

        //    return this;
        //}

        public T SubmitApplication<T>(LoanApplication application) where T : UiComponent, new()
        {
            Input.Model(application);

            return Navigate.To<T>(By.Id("Apply"));
        }
    }
}
