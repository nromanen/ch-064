using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;
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
        private RegisterParams registerParams = ParametersResolver.Resolve<RegisterParams>();

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
            var signUp = header.GoToRegistrationPage();
            LogProgress("Registration page opened.");
            signUp.Registration(registerParams.LocalEmail, registerParams.ExamplePassword, registerParams.ExamplePassword);
            var currentUrl = header.GetCurrentUrl();
            Assert.AreEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page doesn't return.");
            var areCookiesEnabled = header.IsCookieEnabled(registerParams.Cookie);
            Assert.True(areCookiesEnabled, "Cookies are not enabled.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(registerParams.LocalEmail);
            Assert.True(isEmailInHeader, $"User is not presented in header.");
            var getUserFromDB = new UserDAL().GetUserByEmail(registerParams.LocalEmail);
            Assert.NotNull(getUserFromDB, $"Acc doesn't exist in database.");
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            var signUp = header.GoToRegistrationPage();
            LogProgress("Registration page opened.");
            signUp.Registration(registerParams.ExampleEmail, registerParams.ExamplePassword, registerParams.ExamplePassword);
            LogProgress("Registration done.");
            header.SignOut();
            LogProgress("Signed out.");
            var logIn = header.GoToLogInPage();
            LogProgress("Login page opened.");
            logIn.SignIn(registerParams.AdminEmail, registerParams.AdminPassword);
            LogProgress("Signed in as admin.");
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
            LogProgress("Opened admin page.");
            var result = adminPanelPage.IsUserPresentedInUserList(registerParams.ExampleEmail);
            Assert.True(result, "User isn't presented in user list after sign up.");
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
            LogProgress("Went to registration page.");
            var currentPage = signUp.Registration(registerParams.StudentEmail, registerParams.ExamplePassword, registerParams.ExamplePassword);
            LogProgress("Registration done.");
            var isEmailInHeader = header.IsUserEmailPresentedInHeader(registerParams.StudentEmail);
            Assert.False(isEmailInHeader, "User is presented in header.");
            var currentUrl = currentPage.GetCurrentUrl();
            Assert.AreNotEqual(BaseSettings.Fields.Url + "/", currentUrl, "Index page returns.");
            var areCookiesEnabled = currentPage.IsCookieEnabled(registerParams.Cookie);
            Assert.False(areCookiesEnabled, "Cookies are enabled.");
            var isAlertVisible = signUp.IsAlertVisible();
            Assert.True(isAlertVisible, "Alert isn't visible.");

        }
    }
}