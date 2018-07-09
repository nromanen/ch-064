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
    [Collection("MyTestCollection")]
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
                BeginTest();
                var header = ConstructPage<Header>();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                //fixture.test = fixture.extent.StartTest("SignInTest");
                var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
                Assert.True(result);
                //fixture.test.Log(LogStatus.Pass, "User signed in.");
            });
        }

        [Fact]
        public void SignInUsingInvalidEmailTest()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
                Assert.True(header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL));
            });
        }

        [Fact]
        public void SignInUsingInvalidPasswordTest()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
                Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
            });
        }

        [Fact]
        public void SignOutTest()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                driver.RefreshPage();
                header.SignOut();
                driver.RefreshPage();
                Assert.True(logIn.IsSignInPresentedInHeader());
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
