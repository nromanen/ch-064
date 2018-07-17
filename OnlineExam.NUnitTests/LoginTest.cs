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
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;

        public LoginTest()
        {
        }

        [SetUp]
        public void SetUp()
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
        }

        [Test]
        public void SignInTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
                Assert.True(result);
            });
        }

        [Test]
        public void SignInUsingInvalidEmailTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL));
            });
        }

        [Test]
        public void SignInUsingInvalidPasswordTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
            });
        }

        [Test]
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

        [TearDown]
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
