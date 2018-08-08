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
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            header.SignOut();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
            var result = adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL);
            Assert.True(result, "User isn't presented in user list after sign up.");
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            header.GoToHomePage();
            var result = header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL);
            Assert.False(result, "User signed up with used email.");
        }
    }
}