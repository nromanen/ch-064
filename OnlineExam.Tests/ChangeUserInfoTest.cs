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
    public class ChangeUserInfoTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;


        public ChangeUserInfoTest(BaseFixture fixture) : base(fixture)
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

        [Fact]
        public void TestChangeEmail()
        {
            UITest(() =>
            {
                var changeEmailPage = userInfo.OpenChangeEmailPage();
                string newEmail = "teacher@gmail.com";

                changeEmailPage.SetNewEmail(newEmail, Constants.TEACHER_PASSWORD);
                var email = header.GoToUserAccountPage().GetEmail();
                var isEqual = String.Equals(email, newEmail);
                Assert.True(isEqual);

                header.SignOut();
                header.GoToLogInPage().SignIn(newEmail, Constants.TEACHER_PASSWORD);
                header.GoToUserAccountPage();
                var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail);
                Assert.True(isEqualAfterRepeatLogIn);

            });
        }

        [Fact]
        public void TestChangeName()
        {
            UITest(() =>
            {
                var userInfo = header.GoToUserAccountPage();
                var changeNamePage = userInfo.OpenChangeNamePage();

                changeNamePage.SetNewName("teacher@gmail.com", Constants.TEACHER_PASSWORD);
                var newUserName = header.GetHeaderUserName();
                var isEqual = String.Equals(Constants.TEACHER_EMAIL, newUserName, StringComparison.InvariantCultureIgnoreCase);
                Assert.True(isEqual);

            });
        }

        [Fact]
        public void TestChangePassword()
        {
            UITest(() =>
            {
                var changePasswordPage = userInfo.OpenChangePasswordPage();
                var newPassword = "Teacher_123";
                var confirmNewPassword = newPassword;
                changePasswordPage.SetNewPassword("Teacher_123", newPassword, confirmNewPassword);

                header.SignOut();

                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, newPassword);
                header.GoToUserAccountPage();

                var newUserName = header.GetHeaderUserName();
                var isEqual = String.Equals("teacher@gmail.com", newUserName, StringComparison.InvariantCultureIgnoreCase);

                Assert.True(isEqual);

            });
        }
    }
}
