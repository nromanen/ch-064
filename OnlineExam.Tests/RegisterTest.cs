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
    public class RegisterTest : BaseTest, IDisposable
    {
        public RegisterTest()
        {
        }

        [Fact]
        public void SignUpTest()
        {
            var header = ConstructPage<Header>();
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.REGISTRATION_EMAIL, Constants.REGISTRATION_PASSWORD, Constants.REGISTRATION_PASSWORD);
            header.SignOut();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
            Thread.Sleep(1000);

            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.REGISTRATION_EMAIL));
            adminPanelPage.DeleteUser(Constants.REGISTRATION_EMAIL);
        }

        [Fact]
        public void SignUpAsUsedEmail()
        {
            var header = ConstructPage<Header>();
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.STUDENT_EMAIL, Constants.REGISTRATION_PASSWORD, Constants.REGISTRATION_PASSWORD);
            Thread.Sleep(1000);
            header.GoToHomePage();
            Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
