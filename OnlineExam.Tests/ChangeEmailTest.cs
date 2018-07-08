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
            NavigateTo("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = ConstructPage<LogInPage>();
            var indexPage = loginPage.SignIn("teacher@gmail.com", Constants.TEACHER_PASSWORD);
            var header = ConstructPage<Header>();
            
            var userInfo = header.GoToUserAccountPage();
            var changeEmailPage = userInfo.OpenChangeEmailPage();
            string newEmail = "teacher@gmail.com";

            changeEmailPage.SetNewEmail( newEmail, Constants.TEACHER_PASSWORD);
            changeEmailPage.SaveNewEmail();
            header = ConstructPage<Header>();
            userInfo = header.GoToUserAccountPage();
            var userInfoPage = ConstructPage<UserInfoPage>();
            var labelText = userInfoPage.GetEmail();
            var isEqual = String.Equals( labelText, newEmail);
            Assert.True(isEqual);

            header = ConstructPage<Header>();
            header.SignOut();

            
            NavigateTo("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var newLoginPage = ConstructPage<LogInPage>();

            var repeatLogIn = newLoginPage.SignIn(newEmail, Constants.TEACHER_PASSWORD);
            userInfoPage = ConstructPage<UserInfoPage>();
            header = ConstructPage<Header>();
            header.GoToUserAccountPage();
            var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail);

            Assert.True(isEqualAfterRepeatLogIn);
        }
    }
}
