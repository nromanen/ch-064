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
    public class LoginTest : BaseTest
    {
        public LoginTest()
        {
        }

        [Fact]
        public void SignInTest()
        {
           UITest(() =>
           {
               this.driver.GoToUrl(Constants.HOME_URL);
               driver.TakeScreenshot(@"C:\Users\misha\Desktop\ch-064\Screenshots\screenshot.png");
               var header = ConstructPage<Header>();
               var logIn = header.GoToLogInPage();
               logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
               Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
           });
        }

        [Fact]
        public void SignInUsingInvalidEmailTest()
        {
            var header = ConstructPage<Header>();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
            Assert.True(header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL));
        }

        [Fact]
        public void SignInUsingInvalidPasswordTest()
        {
            var header = ConstructPage<Header>();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
            Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
        }

        [Fact]
        public void SignOutTest()
        {
            var header = ConstructPage<Header>();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            //driver.Navigate().Refresh();
            //header.SignOut();
            //driver.Navigate().Refresh();
            throw new Exception("Rewrite using extended ");
            Assert.True(logIn.IsSignInPresentedInHeader());
        }

    }
}
