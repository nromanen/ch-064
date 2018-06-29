using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    public class ChangeEmailTest : BaseTest
    {
        public ChangeEmailTest()
        {
        }

        [Fact]
        public void TestChangeEmail()
        {
            BeginTest();
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = new LogInPage(driver);
            var indexPage = loginPage.SignIn("teacher@gmail.com", Constants.TEACHER_PASSWORD);
            var header = new Header(driver);
            var userInfo = header.GoToUserAccountPage();
            var changeEmailPage = userInfo.OpenChangeEmailPage();
            string newEmail = "teacherTEST@gmail.com";

            changeEmailPage.SetNewEmail( newEmail, Constants.TEACHER_PASSWORD);
            changeEmailPage.SaveNewEmail();
            var userInfoPage = new UserInfoPage(driver);
            var isEqual = String.Equals( userInfoPage.Email.Text, newEmail);

            header = new Header(driver);
            header.SignOut();
            header.GoToLogInPage();
            var newLoginPage = new LogInPage(driver);
            var repeatLogIn = newLoginPage.SignIn(newEmail, Constants.TEACHER_PASSWORD);
            var isEqualAfterRepeatLogIn = string.Equals(userInfoPage.Email.Text, newEmail);

            Assert.True(isEqual || isEqualAfterRepeatLogIn);
        }
    }
}
