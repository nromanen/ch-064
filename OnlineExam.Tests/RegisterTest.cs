using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class RegisterTest : BaseTest
    {
        public RegisterTest()
        {
        }

        [Fact]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.SignOut();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL));
                adminPanelPage.DeleteUser(Constants.EXAMPLE_EMAIL);
            });
        }

        [Fact]
        public void SignUpAsUsedEmail()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.GoToHomePage();
                Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
