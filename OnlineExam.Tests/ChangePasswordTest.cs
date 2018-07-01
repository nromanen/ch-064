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
            var loginPage = new LogInPage(driver);
            var indexPage = loginPage.SignIn("teacher@gmail.com", "Teacher_123");
            var header = new Header(driver);
            var userInfo = header.GoToUserAccountPage();
            var changePasswordPage = userInfo.OpenChangePasswordPage();
            var newPassword = "Teacher_123";
            var confirmNewPassword = newPassword;
            changePasswordPage.SetNewPassword("Teacher_123", newPassword, confirmNewPassword);
            changePasswordPage.SaveNewPassword();

            header = new Header(driver);
            header.SignOut();

            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var repeatLogIn = new LogInPage(driver);
            var repeatSignIn = repeatLogIn.SignIn("teacher@gmail.com", newPassword);

            header = new Header(driver);
            var newUserName = header.GetHeaderUserName();
            var isEqual = String.Equals("teacher@gmail.com", newUserName, StringComparison.InvariantCultureIgnoreCase);

            Assert.True(isEqual);
        }
    }
}
