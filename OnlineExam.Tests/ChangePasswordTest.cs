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
    public class ChangePasswordTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;


        public ChangePasswordTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
        }

        [Fact]
        public void TestChangePassword()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("TestChangePassword");
                //BeginTest();
                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var loginPage = ConstructPage<LogInPage>();
                //var indexPage = loginPage.SignIn("teacher@gmail.com", "Teacher_123");
                //var header = ConstructPage<Header>();
                //var userInfo = header.GoToUserAccountPage();
                var changePasswordPage = userInfo.OpenChangePasswordPage();
                var newPassword = "Teacher_123";
                var confirmNewPassword = newPassword;
                changePasswordPage.SetNewPassword("Teacher_123", newPassword, confirmNewPassword);


                //header = ConstructPage<Header>();
                header.SignOut();

                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var repeatLogIn = ConstructPage<LogInPage>();
                //var repeatSignIn = repeatLogIn.SignIn("teacher@gmail.com", newPassword);

                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, newPassword);
                header.GoToUserAccountPage();

                //header = ConstructPage<Header>();
                var newUserName = header.GetHeaderUserName();
                var isEqual = String.Equals("teacher@gmail.com", newUserName, StringComparison.InvariantCultureIgnoreCase);

                Assert.True(isEqual);
                fixture.test.Log(Status.Pass, "Password is changed");
            });
        }
    }
}
