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
            TestContext.Out.WriteLine("\n<br> " + "Done base set up");
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            var signUp = header.GoToRegistrationPage();
            TestContext.Out.WriteLine("\n<br> " + "Registration page opened.");
            signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            TestContext.Out.WriteLine("\n<br> " + "Registration done.");
            header.SignOut();
            TestContext.Out.WriteLine("\n<br> " + "Signed out.");
            var logIn = header.GoToLogInPage();
            TestContext.Out.WriteLine("\n<br> " + "Login page opened.");
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            TestContext.Out.WriteLine("\n<br> " + $"Signed in as {Constants.ADMIN_EMAIL}.");
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
            TestContext.Out.WriteLine("\n<br> " + "Opened admin page.");
            var result = adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL);
            Assert.True(result, "User isn't presented in user list after sign up.");
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
            TestContext.Out.WriteLine("\n<br> " + "Went to registration page.");
            signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            TestContext.Out.WriteLine("\n<br> " + "Registration done.");
            header.GoToHomePage();
            TestContext.Out.WriteLine("\n<br> " + "Went to home page.");
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.False(result, "User signed up with used email.");
        }
    }
}