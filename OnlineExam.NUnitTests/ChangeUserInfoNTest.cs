using NUnit.Framework;
using OnlineExam.Framework;
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

        }

        [Test]
        public void TestChangeEmail()
        {

            logInPage.SignIn("UserForChangeEmail@gmail.com", Constants.USER_PASSWORD);
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
            Assert.False(flag, "Email was changed on UI but not in DB");
            header.GoToUserAccountPage();
            var isEqualAfterRepeatLogIn = string.Equals(userInfo.GetEmail(), newEmail, StringComparison.InvariantCulture);
            Assert.True(isEqualAfterRepeatLogIn);

        }

        [Test]
        public void TestChangeName()
        {

            logInPage.SignIn(Constants.USER_FOR_CHANGE_NAME, Constants.USER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
            var changeNamePage = userInfo.OpenChangeNamePage();
            var newName = "NewName";
            changeNamePage.SetNewName(newName, Constants.USER_PASSWORD);
            var newUserNameFromHeader = header.GetHeaderUserName();
            var isEqual = String.Equals(newName, newUserNameFromHeader, StringComparison.InvariantCultureIgnoreCase);
            Assert.True(isEqual);

        }

        [Test]
        public void TestChangePassword()
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

        }

    }
}
