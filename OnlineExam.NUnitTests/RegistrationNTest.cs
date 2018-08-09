using NUnit.Framework;
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
            TestContext.Progress.WriteLine("Done base set up");
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            var signUp = header.GoToRegistrationPage();
            TestContext.Progress.WriteLine("Registration page opened.");
            signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            TestContext.Progress.WriteLine("Registration done.");
            header.SignOut();
            TestContext.Progress.WriteLine("Signed out.");
            var logIn = header.GoToLogInPage();
            TestContext.Progress.WriteLine("Login page opened.");
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            TestContext.Progress.WriteLine($"Signed in as {Constants.ADMIN_EMAIL}.");
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
            TestContext.Progress.WriteLine("Opened admin page.");
            var result = adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL);
            Assert.True(result, "User isn't presented in user list after sign up.");
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
            TestContext.Progress.WriteLine("Went to registration page.");
            signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            TestContext.Progress.WriteLine("Registration done.");
            header.GoToHomePage();
            TestContext.Progress.WriteLine("Went to home page.");
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.False(result, "User signed up with used email.");
        }
    }
}