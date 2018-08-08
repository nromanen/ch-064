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
            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
        }

        [Test]
        public void SignInTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.True(result, $"User {Constants.STUDENT_EMAIL} is not presented in header.");
        }

        [Test]
        public void SignInUsingInvalidEmailTest()
        {
            logInPage.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
            var result = header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL);
            Assert.False(result, $"Fake user {Constants.FAKE_EMAIL} is presented in header.");
        }

        [Test]
        public void SignInUsingInvalidPasswordTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.False(result, $"User {Constants.STUDENT_EMAIL} is presented in header.");
        }

        [Test]
        public void SignOutTest()
        {
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            header.SignOut();
            var result = logInPage.IsSignInPresentedInHeader();
            Assert.True(result, "User didn't sign out. Sign in button isn't presented in header.");
        }
    }
}