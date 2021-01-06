using BankingSite.Models;
using HtmlAgilityPack;
using NUnit.Framework;
using RazorGenerator.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSite.ViewTest
{
    [TestFixture ]
    public class LoanApplicationSearchApplicationStatusViewTests
    {
        [Test]
        public void ShouldRenderAcceptedMessage()
        {
            var sut = new Views.LoanApplicationSearch.ApplicationStatus();

            var model = new LoanApplication
            {
                IsAccepted = true
            };

            HtmlDocument html = sut.RenderAsHtml(model);

            //var message = html.GetElementbyId("status").InnerText;
            //Assert.That(message, Contains.Substring("Yay! Accepted!"));

            var isAcceptedMessageRendred = html.GetElementbyId("acceptedMessage") != null;
            var isAcDeclinedMessageRendred = html.GetElementbyId("declinedMessage") != null;
            Assert.That(isAcceptedMessageRendred, Is.True);
            Assert.That(isAcDeclinedMessageRendred, Is.False);
        }
    }
}
