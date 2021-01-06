using System;
using System.Web.Mvc;
using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class LoanApplicationControllerTests
    {
        [Test]
        public void ShouldRenderDefaultView()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var result = sut.Apply() as ViewResult;

            sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();
        }

        [Test]
        public void ShouldRedirectToAcceptedViewOnSuccessfulApplication()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var acceptedApplication = new LoanApplication
            {
                IsAccepted = true
            };

            sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Accepted);
        }

        [Test]
        public void ShouldRedirectToDeclinedViewOnUnsuccessfulApplication()
        {
            var fakeRepository = new Mock<IRepository>();
            var fakeLoanApplicationScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepository.Object, fakeLoanApplicationScorer.Object);

            var acceptedApplication = new LoanApplication
            {
                IsAccepted = false
            };

            sut.WithCallTo(x => x.Apply(acceptedApplication)).ShouldRedirectTo<int>(x => x.Declined);
        }
    }
}
