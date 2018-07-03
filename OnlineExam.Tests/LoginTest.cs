using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Xunit;

namespace OnlineExam.Tests
{
    public class LoginTest : BaseTest, IDisposable
    {
        public LoginTest()
        {
        }
        [Fact]
        public void SignInTest()
        {
            var header = new Header(driver);
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            Assert.True(logIn.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
        }

        [Fact]
        public void SignOutTest()
        {
            var header = new Header(driver);
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().Refresh();
            header.SignOut();
            driver.Navigate().Refresh();
            Assert.True(logIn.IsSignInPresentedInHeader());
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
