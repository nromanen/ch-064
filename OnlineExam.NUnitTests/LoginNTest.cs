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
                Assert.True(result);
        }

        [Test]
        public void SignInUsingInvalidEmailTest()
        {
           
                logInPage.SignIn(Constants.FAKE_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.FAKE_EMAIL));
        }

        [Test]
        public void SignInUsingInvalidPasswordTest()
        {
            
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.FAKE_PASSWORD);
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
        }

        [Test]
        public void SignOutTest()
        {
            
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                driver.RefreshPage();
                header.SignOut();
                driver.RefreshPage();
                Assert.True(logInPage.IsSignInPresentedInHeader());
        }
    }
}