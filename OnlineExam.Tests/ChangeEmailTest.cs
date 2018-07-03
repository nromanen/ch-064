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
            var header2 = ConstructPage<Header>();
            if(header2 != null)
            {
                header2.GoToHomePage();
            }
            var userInfo = header.GoToUserAccountPage();
            var changeEmailPage = userInfo.OpenChangeEmailPage();
            string newEmail = "teacher@gmail.com";

            changeEmailPage.SetNewEmail( newEmail, Constants.TEACHER_PASSWORD);
            changeEmailPage.SaveNewEmail();
            header = new Header(driver);
            userInfo = header.GoToUserAccountPage();
            var userInfoPage = new UserInfoPage(driver);
            var labelText = userInfoPage.GetEmail();
            var isEqual = String.Equals( labelText, newEmail);
            Assert.True(isEqual);

            header = new Header(driver);
            header.SignOut();

            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var newLoginPage = new LogInPage(driver);
            
            var repeatLogIn = newLoginPage.SignIn(newEmail, Constants.TEACHER_PASSWORD);
            userInfoPage = new UserInfoPage(driver);
            header = new Header(driver);
            header.GoToUserAccountPage();
            var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail);

            Assert.True(isEqualAfterRepeatLogIn);
        }
    }
}
