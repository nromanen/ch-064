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
    [TestFixture]
    public class RegistrationNTest : BaseNTest
    {
        private Header header;
        private SideBar sideBar;

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
            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL));
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
            header.GoToHomePage();
            Assert.False(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
        }
    }
}