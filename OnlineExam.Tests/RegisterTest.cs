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
            var header = new Header(driver);
            var signUp = header.GoToRegistrationPage();
            signUp.Registration(Constants.REGISTRATION_EMAIL, Constants.REGISTRATION_PASSWORD, Constants.REGISTRATION_PASSWORD);
            header.SignOut();
            var logIn = header.GoToLogInPage();
            logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);

            var adminPanelPage = new SideBar(driver).AdminPanelMenuItemClick();
            Thread.Sleep(1000);

            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.REGISTRATION_EMAIL));
            adminPanelPage.DeleteUser(Constants.REGISTRATION_EMAIL);
        }


        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
