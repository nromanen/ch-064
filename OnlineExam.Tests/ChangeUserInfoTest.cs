using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
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
           
        }

        //[Fact]
        public void CheckContentUserInfoPageTest()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                userInfo = header.GoToUserAccountPage();
                var isOpened = driver.GetCurrentUrl().EndsWith("/User");
                Assert.True(isOpened);

                var userInfoPage = ConstructPage<UserInfoPage>();
                Assert.True(userInfoPage.HasChangePasswordButton());
                Assert.True(userInfoPage.HasChangeNameButton());
                Assert.True(userInfoPage.HasChangeEmailButton());

                var userEmail = userInfoPage.GetEmail();
                var isEqual = String.Equals(userEmail, Constants.TEACHER_EMAIL);
                Assert.True(isEqual);

            });
        }

        //[Fact]
        public void TestChangeEmail()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.USER_FOR_CHANGE_EMAIL, Constants.USER_PASSWORD);
                userInfo = header.GoToUserAccountPage();

                var changeEmailPage = userInfo.OpenChangeEmailPage();
                string newEmail = "NewEmail@gmail.com";

                changeEmailPage.SetNewEmail(newEmail, Constants.USER_PASSWORD);
                var email = header.GoToUserAccountPage().GetEmail();
                var isEqual = String.Equals(email, newEmail);
                Assert.True(isEqual);

                header.SignOut();
                header.GoToLogInPage().SignIn("NewEmail@gmail.com", Constants.USER_PASSWORD);
                var flag = header.GetCurrentUrl().Contains(Constants.LOGIN_URL_CONTAINS);
                Assert.False(flag,"Email was changed on UI but not in DB");
                header.GoToUserAccountPage();
                var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail,StringComparison.InvariantCulture);
                Assert.True(isEqualAfterRepeatLogIn);

            });
        }

        //[Fact]
        public void TestChangeName()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.USER_FOR_CHANGE_NAME, Constants.USER_PASSWORD);
                userInfo = header.GoToUserAccountPage();
                var changeNamePage = userInfo.OpenChangeNamePage();
                var newName = "NewName";
                changeNamePage.SetNewName(newName, Constants.USER_PASSWORD);
                var newUserNameFromHeader = header.GetHeaderUserName();
                var isEqual = String.Equals(newName, newUserNameFromHeader, StringComparison.InvariantCultureIgnoreCase);
                Assert.True(isEqual);

            });
        }

        //[Fact]
        public void TestChangePassword()
        {
            UITest(() =>
            {
                logInPage.SignIn(Constants.USER_FOR_CHANGE_PASSWORD, Constants.USER_PASSWORD);
                userInfo = header.GoToUserAccountPage();
                var changePasswordPage = userInfo.OpenChangePasswordPage();
                var newPassword = "NewNewNew_123";
                var confirmNewPassword = newPassword;
                changePasswordPage.SetNewPassword(Constants.USER_PASSWORD, newPassword, confirmNewPassword);

                header.SignOut();

                header.GoToLogInPage().SignIn(Constants.USER_FOR_CHANGE_PASSWORD, newPassword);
                header.GoToUserAccountPage();

                var newUserName = header.GetHeaderUserName();
                var isEqual = String.Equals(Constants.USER_FOR_CHANGE_PASSWORD, newUserName, StringComparison.InvariantCultureIgnoreCase);

                Assert.True(isEqual);

            });
        }
    }
}
