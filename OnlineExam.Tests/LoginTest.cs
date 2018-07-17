using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class LoginTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;

        public LoginTest(BaseFixture fixture) : base(fixture)
        {
                BeginTest();
                header = ConstructPage<Header>();
                logInPage = header.GoToLogInPage();
        }


        [Fact]
        public void SignInTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
                Assert.True(result);
            });
        }

        [Fact]
        public void SignInUsingInvalidEmailTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL));
            });
        }

        [Fact]
        public void SignInUsingInvalidPasswordTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
            });
        }

        [Fact]
        public void SignOutTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                driver.RefreshPage();
                header.SignOut();
                driver.RefreshPage();
                Assert.True(logInPage.IsSignInPresentedInHeader());
            });
        }
    }
}