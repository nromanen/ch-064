using System;
using AventStack.ExtentReports;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using Xunit;
using Xunit.Abstractions;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class AdminTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private AdminPanelPage adminPanelPage;


        //[SetUp]
        public AdminTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
        }

        //[Fact]
        public void IsUserPresentedInUserListTest()
        {
            UITest(() =>
            {
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL));
            });
        }

        //[Fact]
        public void DeleteUserTest()
        {
            UITest(() =>
            {
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL),
                    "User is not presented in the system," +
                    "so we have not opportunity to delete this user");
                adminPanelPage.DeleteUser(Constants.USER_FOR_DELETE_EMAIL);

                Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
                Assert.False(adminPanelPage.IsUserPresentedInUserList(Constants.USER_FOR_DELETE_EMAIL), "Error");

            });
        }

        //[Fact]
        public void ChangeUserRoleTest()
        {
            UITest(() =>
            {
                var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);
                changeRolePage.ChangeRole(Constants.TEACHER);
                changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.USER_FOR_CHANGE_ROLE_EMAIL);
                Assert.Equal(Constants.TEACHER, changeRolePage.CurrentRole());
            });
        }

        //[Fact]
        public void IsUserListAvailableTest()
        {
            UITest(() =>
            {
                Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
            });
        }
    }
}