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
    public class RegistrationTest : BaseTest
    {
        private Header header;
        private SideBar sideBar;

        [SetUp]
        public void SetUp()
        {
            BeginTest();
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            UITest(() =>
            {
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.SignOut();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL));
            });
        }

        [Test]
        public void SignUpAsUsedEmail()
        {
            UITest(() =>
            {
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.GoToHomePage();
                Assert.False(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));

            });
        }

        [TearDown]
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}