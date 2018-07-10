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
    public class CheckContentUserInfoPage : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;


        public CheckContentUserInfoPage(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
        }

        [Fact]
        public void CheckContentUserInfoPageTest()
        {
            UITest(() =>
            {
                //BeginTest();
                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var loginPage = ConstructPage<LogInPage>();
                //var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
                //var header = ConstructPage<Header>();
                //var userInfo = header.GoToUserAccountPage();

                var isOpened = driver.GetCurrentUrl().EndsWith("/User");
                Assert.True(isOpened);

                var userInfoPage = ConstructPage<UserInfoPage>();
                Assert.True(userInfoPage.HasChangePasswordButton());
                Assert.True(userInfoPage.HasChangeNameButton());
                Assert.True(userInfoPage.HasChangeEmailButton());

                var userEmail = userInfoPage.GetEmail();
                var isEqual = String.Equals(userEmail, "teacher@gmail.com");
                Assert.True(isEqual);
            });
        }
    }
}
