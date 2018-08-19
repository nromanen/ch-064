using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.NUnitTests.Params;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [Category("Basic")]
    [TestFixture]
    public class ChangeUserInfoNTest : BaseNTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();

        }

        [Test]
        public void CheckContentUserInfoPageTest()
        {
            LogProgress($"User logging with e-mail:{Constants.TEACHER_EMAIL} and password : {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            LogProgress("Opening User accoumt page");
            userInfo = header.GoToUserAccountPage();
            var isOpened = driver.GetCurrentUrl().EndsWith("/User");
            Assert.True(isOpened);
            LogProgress("All buttons are present on User account page");
            var userInfoPage = ConstructPage<UserInfoPage>();
            Assert.True(userInfoPage.HasChangePasswordButton());
            Assert.True(userInfoPage.HasChangeNameButton());
            Assert.True(userInfoPage.HasChangeEmailButton());
            LogProgress("Getting e-mail");
            var userEmail = userInfoPage.GetEmail();
            var isEqual = String.Equals(userEmail, Constants.TEACHER_EMAIL);
            Assert.True(isEqual);

        }

        [Test]
        public void TestChangeEmail()
        {
            LogProgress($"User logging with e-mail: UserForChangeEmail@gmail.com and password : {Constants.USER_PASSWORD}");
            logInPage.SignIn("UserForChangeEmail@gmail.com", Constants.USER_PASSWORD);
            LogProgress("Opening User accoumt page");
            userInfo = header.GoToUserAccountPage();
            LogProgress("Opening Change email page");
            var changeEmailPage = userInfo.OpenChangeEmailPage();
            LogProgress("Setting new e-mail");
            string newEmail = "NewEmail@gmail.com";
            changeEmailPage.SetNewEmail(newEmail, Constants.USER_PASSWORD);
            var email = header.GoToUserAccountPage().GetEmail();
            var isEqual = String.Equals(email, newEmail);
            Assert.True(isEqual);
            LogProgress("Logging out");
            header.SignOut();
            LogProgress("Logging with new e-mail");
            header.GoToLogInPage().SignIn("NewEmail@gmail.com", Constants.USER_PASSWORD);
            var flag = header.GetCurrentUrl().Contains(Constants.LOGIN_URL_CONTAINS);
            Assert.False(flag, "Email was changed on UI but not in DB");
            header.GoToUserAccountPage();
            var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail, StringComparison.InvariantCulture);
            Assert.True(isEqualAfterRepeatLogIn);

        }

        [Test]
        public void TestChangeName()
        {
            ChangeNameParam param = ParamsResolver.Resolve("ChangeUserInfo.ChangeName.json");
            LogProgress($"User logging with e-mail: {Constants.USER_FOR_CHANGE_NAME} and password : {Constants.USER_PASSWORD}");
            logInPage.SignIn(param.Name, param.Password);
            LogProgress("Opening User accoumt page");
            userInfo = header.GoToUserAccountPage();
            LogProgress("Opening Change name page");
            var changeNamePage = userInfo.OpenChangeNamePage();
            LogProgress("Setting new name");
           
            changeNamePage.SetNewName(param.NewName, param.Password);
            var newUserNameFromHeader = header.GetHeaderUserName();
            var isEqual = String.Equals(param.NewName, newUserNameFromHeader, StringComparison.InvariantCultureIgnoreCase);
            Assert.True(isEqual);

        }

        [Test]
        public void TestChangePassword()
        {
            LogProgress($"User logging with e-mail: {Constants.USER_FOR_CHANGE_PASSWORD} and password : {Constants.USER_PASSWORD}");
            logInPage.SignIn(Constants.USER_FOR_CHANGE_PASSWORD, Constants.USER_PASSWORD);
            LogProgress("Opening User accoumt page");
            userInfo = header.GoToUserAccountPage();
            LogProgress("Opening Change password page");
            var changePasswordPage = userInfo.OpenChangePasswordPage();
            LogProgress("Setting new password");
            var newPassword = "NewNewNew_123";
            var confirmNewPassword = newPassword;
            changePasswordPage.SetNewPassword(Constants.USER_PASSWORD, newPassword, confirmNewPassword);
            LogProgress("Logging out");
            header.SignOut();
            LogProgress("Logging with new password");
            header.GoToLogInPage().SignIn(Constants.USER_FOR_CHANGE_PASSWORD, newPassword);
            header.GoToUserAccountPage();

            var newUserName = header.GetHeaderUserName();
            var isEqual = String.Equals(Constants.USER_FOR_CHANGE_PASSWORD, newUserName, StringComparison.InvariantCultureIgnoreCase);

            Assert.True(isEqual);

        }

    }
}
