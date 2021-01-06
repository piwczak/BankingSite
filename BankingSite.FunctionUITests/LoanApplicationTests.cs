using BankingSite.Controllers;
using BankingSite.FunctionUITests.DemoHelperCode;
using BankingSite.FunctionUITests.PageObjectModel;
using BankingSite.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.Seleno.Configuration;
using TestStack.Seleno.Configuration.WebServers;

namespace BankingSite.FunctionUITests
{
    [TestFixture]
    public class LoanApplicationTests
    {
        [Test]
        public void ShouldAcceptLoanApplication()
        {
            //BrowserHost.Instance.Application.Browser.Navigate()
            //    .GoToUrl(BrowserHost.RootUrl + @"LoanApplicatin\Apply");

            //var firstNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("FirstName"));
            //firstNameBox.SendKeys("Gentry");

            //var lastNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("LastName"));
            //lastNameBox.SendKeys("Smith");

            //var ageBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Age"));
            //ageBox.SendKeys("42");

            //var incomeBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("AnnualIncome"));
            //incomeBox.SendKeys("99999999");

            //DemoHelper.Wait();

            //var applyButon = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Apply"));
            //applyButon.Click();

            //DemoHelper.Wait(5000);

            //var accpetMessageText = BrowserHost.Instance.Application.Browser.FindElement(By.Id("acceptMessage"));

            //Assert.That(accpetMessageText.Text, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

            //DemoHelper.Wait(5000);

            var applyPage = BrowserHost.Instance.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(
                x => x.Apply());

            //var acceptPage = applyPage.EnterFirstName("Gentry")
            //    .EnterLastName("Smith")
            //    .EnterAge("42")
            //    .EnterAnnualIncome("99999999")
            //    .SubmitApplication<AcceptedPage>();

            var applicationDetail = new LoanApplication
            {
                FirstName = "Gentry",
                LastName = "Smith",
                Age = 42,
                AnnualIncome = 99999999
            };

            var acceptPage = applyPage.SubmitApplication<AcceptedPage>(applicationDetail);

            DemoHelper.Wait(5000);

            var accpetMessageText = acceptPage.AcceptedMessage;

            Assert.That(accpetMessageText, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

            DemoHelper.Wait(5000);

        }

        [Test]
        public void ShouldDeclineLoanApplication()
        {
            //    BrowserHost.Instance.Application.Browser.Navigate()
            //        .GoToUrl(BrowserHost.RootUrl + @"LoanApplicatin\Apply");

            //    var firstNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("FirstName"));
            //    firstNameBox.SendKeys("Gentry");

            //    var lastNameBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("LastName"));
            //    lastNameBox.SendKeys("Smith");

            //    var ageBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Age"));
            //    ageBox.SendKeys("16");

            //    var incomeBox = BrowserHost.Instance.Application.Browser.FindElement(By.Id("AnnualIncome"));
            //    incomeBox.SendKeys("20000S");

            //    DemoHelper.Wait();

            //    var applyButon = BrowserHost.Instance.Application.Browser.FindElement(By.Id("Apply"));
            //    applyButon.Click();

            //    DemoHelper.Wait(5000);

            //    var accpetMessageText = BrowserHost.Instance.Application.Browser.FindElement(By.Id("declineMessage"));

            //    Assert.That(accpetMessageText.Text, Is.EqualTo("Sorry Gentry - We are unable to offer you a loan at this time."));

            //    DemoHelper.Wait(5000);

            var applyPage = BrowserHost.Instance.NavigateToInitialPage<LoanApplicationController, LoanApplicationPage>(
               x => x.Apply());

            //var declinePage = applyPage.EnterFirstName("Gentry")
            //    .EnterLastName("Smith")
            //    .EnterAge("16")
            //    .EnterAnnualIncome("20000")
            //    .SubmitApplication<DeclinedPage>(); ;

            var applicationDetail = new LoanApplication
            {
                FirstName = "Gentry",
                LastName = "Smith",
                Age = 16,
                AnnualIncome = 20000
            };

            var declinePage = applyPage.SubmitApplication<DeclinedPage>(applicationDetail);

            DemoHelper.Wait(5000);

            Assert.That(declinePage.DeclinedMessage, Is.EqualTo("Congratulations Gentry - Your application was accepted!"));

            DemoHelper.Wait(5000);
        }
    }
}
