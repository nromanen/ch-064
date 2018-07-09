using System;
using AventStack.ExtentReports;
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

        [Fact]
        public void IsUserPresentedInUserListTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("IsUserPresentedInUserListTest");
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL));
                fixture.test.Log(Status.Pass, "User is presented in user list");
                //fixture.test.Pass("User is presented in user list");
            });
        }

        [Fact]
        public void DeleteUserTest()
        {
            UITest(() =>
            {
                BackupDatabase();
                fixture.test = fixture.extentReports.CreateTest("Delete user test");
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL),
                    "User is not presented in the system," +
                    "so we have not opportunity to delete this user");
                adminPanelPage.DeleteUser(Constants.STUDENT_EMAIL);

                Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
                Assert.False(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL), "Error");

                fixture.test.Log(Status.Pass, "User is deleted successfully");
                RollbackDatabase();
                //fixture.test.Pass("User is deleted successfully");
            });
        }

        [Fact]
        public void ChangeUserRoleTest()
        {
            UITest(() =>
            {
                BackupDatabase();
                fixture.test = fixture.extentReports.CreateTest("Change user role test");
                var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.STUDENT_EMAIL);
               // changeRolePage.ChangeRole(Constants.STUDENT);
                changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.STUDENT_EMAIL);
                Assert.Equal(Constants.STUDENT, changeRolePage.CurrentRole());
                fixture.test.Log(Status.Pass, "Role is changed successfully");
                RollbackDatabase();
                // fixture.test.Pass("Role is changed successfully");
            });
        }

        [Fact]
        public void IsUserListAvailableTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("Is user list available test");
                Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
                fixture.test.Log(Status.Pass, "User list is available");
                // fixture.test.Pass("User list is available");
            });
        }
        }
}