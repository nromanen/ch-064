using AventStack.ExtentReports;
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
    [Collection("MyTestCollection")]
    public class ChangeEmailTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;


       public ChangeEmailTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
        }


        [Fact]
        public void TestChangeEmail()
        {
            UITest(() =>
            {

                //BeginTest();
                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var loginPage = ConstructPage<LogInPage>();
                //var indexPage = loginPage.SignIn("teacher@gmail.com", Constants.TEACHER_PASSWORD);
                //var header = ConstructPage<Header>();

                //var userInfo = header.GoToUserAccountPage();
                var changeEmailPage = userInfo.OpenChangeEmailPage();
                string newEmail = "teacher@gmail.com";

                changeEmailPage.SetNewEmail(newEmail, Constants.TEACHER_PASSWORD);
                //header = ConstructPage<Header>();


                var email = header.GoToUserAccountPage().GetEmail();
                var isEqual = String.Equals(email, newEmail);
                Assert.True(isEqual);

                header.SignOut();
                header.GoToLogInPage().SignIn(newEmail, Constants.TEACHER_PASSWORD);
                header.GoToUserAccountPage();
                var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail);
                Assert.True(isEqualAfterRepeatLogIn);


                //userInfo = header.GoToUserAccountPage();
                //var userInfoPage = ConstructPage<UserInfoPage>();
                //var labelText = userInfoPage.GetEmail();
                //var isEqual = String.Equals( labelText, newEmail);
                //Assert.True(isEqual);

                //header = ConstructPage<Header>();
                //header.SignOut();


                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var newLoginPage = ConstructPage<LogInPage>();

                //var repeatLogIn = newLoginPage.SignIn(newEmail, Constants.TEACHER_PASSWORD);
                //userInfoPage = ConstructPage<UserInfoPage>();
                //header = ConstructPage<Header>();
                //header.GoToUserAccountPage();
                //var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail);

                //Assert.True(isEqualAfterRepeatLogIn);
            });
        }
    }
}
