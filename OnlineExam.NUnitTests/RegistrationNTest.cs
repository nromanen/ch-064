using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Critical")]

    public class RegistrationNTest : BaseNTest
    {
        private Header header;
        private SideBar sideBar;

        public RegistrationNTest()
        {
        }
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
           LogProgress("Done base set up");
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void SignUp()
        {
            string localEmail = "loll@dmail.com";
            var signUp = header.GoToRegistrationPage();
           LogProgress("Registration page opened.");
            signUp.Registration(localEmail, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page doesn't return.");
            var areCookiesEnabled = header.IsCookieEnabled(".AspNetCore.Identity.Application");
            Assert.True(areCookiesEnabled, "Cookies are not enabled.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(localEmail);
            Assert.True(isEmailInHeader, $"User is not presented in header.");
            var getUserFromDB = new UserDAL().GetUserByEmail(localEmail);
            Assert.NotNull(getUserFromDB, $"Acc doesn't exist in database.");
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            var signUp = header.GoToRegistrationPage();
           LogProgress("Registration page opened.");
            signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
           LogProgress("Registration done.");
            header.SignOut();
           LogProgress("Signed out.");
            var logIn = header.GoToLogInPage();
           LogProgress("Login page opened.");
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
           LogProgress($"Signed in as {Constants.ADMIN_EMAIL}.");
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
           LogProgress("Opened admin page.");
            var result = adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL);
            Assert.True(result, "User isn't presented in user list after sign up.");
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
           LogProgress("Went to registration page.");
            var currentPage = signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
           LogProgress("Registration done.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(Constants.EXAMPLE_EMAIL);
            Assert.False(isEmailInHeader, $"User {Constants.EXAMPLE_EMAIL} is presented in header.");
            var currentUrl = currentPage.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var areCookiesEnabled = currentPage.IsCookieEnabled(".AspNetCore.Identity.Application");
            Assert.False(areCookiesEnabled, "Cookies are enabled.");
            var isAlertVisible = signUp.IsAlertVisible();
            Assert.True(isAlertVisible, "Alert isn't visible.");

        }
    }
}