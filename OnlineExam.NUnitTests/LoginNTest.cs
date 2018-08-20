using NUnit.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Critical")]
    [Category("Basic")]
    [Category("Mini")]
    public class LoginNTest : BaseNTest
    {
        private Header header;
        private LogInPage logInPage;
        private LoginParams loginParams = ParametersResolver.Resolve<LoginParams>();

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
           LogProgress("Done base set up");
            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
           LogProgress("Went to log in page.");
        }

        [Test]
        public void SignInTest()
        {
            logInPage.SignIn(loginParams.StudentEmail, loginParams.StudentPassword);
            LogProgress("Signed in.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(loginParams.StudentEmail);
            Assert.True(isEmailInHeader, "User is not presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url+"/" , currentUrl, "Index page doesn't return.");
            var cookies = logInPage.IsCookieEnabled(loginParams.Cookie);
            Assert.True(cookies, "Cookies are not enabled.");
        }

        [Test]
        public void SignInUsingInvalidEmailTest()
        {
            logInPage.SignIn(loginParams.FakeEmail, loginParams.FakePassword);
            LogProgress("Signed in.");
            var result = header.IsUserEmailPresentedInHeader(loginParams.FakeEmail);
            Assert.False(result, "User is presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var isAlertDisplayed = logInPage.IsAlertVisible();
            Assert.True(isAlertDisplayed, "Alert isn't displayed.");
        }

        [Test]
        public void SignInUsingInvalidPasswordTest()
        {
            logInPage.SignIn(loginParams.StudentEmail, loginParams.FakePassword);
            var result = header.IsUserEmailPresentedInHeader(loginParams.StudentEmail);
            Assert.False(result, "User is presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var isAlertDisplayed = logInPage.IsAlertVisible();
            Assert.True(isAlertDisplayed, "Alert isn't displayed.");
        }

        [Test]
        public void SignOutTest()
        {
            logInPage.SignIn(loginParams.StudentEmail, loginParams.StudentPassword);
            LogProgress("Signed in .");
            header.SignOut();
            LogProgress($"Signed out.");
            var result = logInPage.IsSignInPresentedInHeader();
            Assert.True(result, "Sign in button isn't presented in header.");
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page doesn't return.");
            var cookies = logInPage.IsCookieEnabled(loginParams.Cookie);
            Assert.False(cookies, "Cookies are enabled.");
        }
    }
}