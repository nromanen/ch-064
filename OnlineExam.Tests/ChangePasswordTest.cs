using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    public class ChangePasswordTest : BaseTest
    {
        public ChangePasswordTest()
        {
        }

        [Fact]
        public void TestChangePassword()
        {
            BeginTest();
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = ConstructPage<LogInPage>();
            var indexPage = loginPage.SignIn("teacher@gmail.com", "Teacher_123");
            var header = ConstructPage<Header>();
            var userInfo = header.GoToUserAccountPage();
            var changePasswordPage = userInfo.OpenChangePasswordPage();
            var newPassword = "Teacher_123";
            var confirmNewPassword = newPassword;
            changePasswordPage.SetNewPassword("Teacher_123", newPassword, confirmNewPassword);
            changePasswordPage.SaveNewPassword();

            header = ConstructPage<Header>();
            header.SignOut();

            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var repeatLogIn = ConstructPage<LogInPage>();
            var repeatSignIn = repeatLogIn.SignIn("teacher@gmail.com", newPassword);

            header = ConstructPage<Header>();
            var newUserName = header.GetHeaderUserName();
            var isEqual = String.Equals("teacher@gmail.com", newUserName, StringComparison.InvariantCultureIgnoreCase);

            Assert.True(isEqual);
        }
    }
}
