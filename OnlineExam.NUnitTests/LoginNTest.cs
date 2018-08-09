using NUnit.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Critical")]
    [Category("Basic")]
    public class LoginNTest : BaseNTest
    {
        private Header header;
        private LogInPage logInPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestContext.Progress.WriteLine("Done base set up");
            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            TestContext.Progress.WriteLine("Went to log in page.");
        }

        [Test]
        public void SignInTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            TestContext.Progress.WriteLine($"Signed in as {Constants.STUDENT_EMAIL}.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.True(isEmailInHeader, $"User {Constants.STUDENT_EMAIL} is not presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url+"/" , currentUrl, "Index page doesn't return.");
            var cookies = logInPage.IsCookieEnabled(".AspNetCore.Identity.Application");
            Assert.True(cookies, "Cookies are not enabled.");
        }

        [Test]
        public void SignInUsingInvalidEmailTest()
        {
            logInPage.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
            TestContext.Progress.WriteLine($"Signed in as {Constants.FAKE_EMAIL}.");
            var result = header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL);
            Assert.False(result, $"Fake user {Constants.FAKE_EMAIL} is presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var isAlertDisplayed = logInPage.IsAlertVisible();
            Assert.True(isAlertDisplayed, "Alert isn't displayed.");
        }

        [Test]
        public void SignInUsingInvalidPasswordTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.False(result, $"User {Constants.STUDENT_EMAIL} is presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var isAlertDisplayed = logInPage.IsAlertVisible();
            Assert.True(isAlertDisplayed, "Alert isn't displayed.");
        }

        [Test]
        public void SignOutTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            TestContext.Progress.WriteLine($"Signed in as {Constants.STUDENT_EMAIL}.");
            header.SignOut();
            TestContext.Progress.WriteLine($"Signed out.");
            var result = logInPage.IsSignInPresentedInHeader();
            Assert.True(result, "Sign in button isn't presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page doesn't return.");
            var cookies = logInPage.IsCookieEnabled(".AspNetCore.Identity.Application");
            Assert.False(cookies, "Cookies are enabled.");
        }
    }
}