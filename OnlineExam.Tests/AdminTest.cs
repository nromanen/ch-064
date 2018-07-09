using System.Collections.Generic;
using OnlineExam.Pages.POM;
using RelevantCodes.ExtentReports;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class AdminTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private AdminPanelPage adminPanelPage;


        //[SetUp]
        public AdminTest (BaseFixture fixture) : base(fixture)
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
            fixture.test = fixture.extent.StartTest("IsUserPresentedInUserListTest");
            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL));
            fixture.test.Log(LogStatus.Pass, "User is presented in user list");
        }

        [Fact]
        public void DeleteUserTest()
        {
            fixture.test = fixture.extent.StartTest("Delete user test");
            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.VIKTOR_EMAIL),
                "User is not presented in the system," +
                "so we have not opportunity to delete this user");
            adminPanelPage.DeleteUser(Constants.VIKTOR_EMAIL);
            //    fixture.test.Log(LogStatus.Fail,"failed");
            
            Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
            Assert.False(adminPanelPage.IsUserPresentedInUserList(Constants.VIKTOR_EMAIL), "Error");
            fixture.test.Log(LogStatus.Pass, "User is deleted successfully");
        }

        [Fact]
        public void ChangeUserRoleTest()
        {
            fixture.test = fixture.extent.StartTest("Change user role test");
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            changeRolePage.ChangeRole(Constants.STUDENT);
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            Assert.Equal(Constants.TEACHER, changeRolePage.CurrentRole());
            fixture.test.Log(LogStatus.Pass, "Role is changed successfully");
        }

        [Fact]
        public void IsUserListAvailableTest()
        {
            fixture.test = fixture.extent.StartTest("Is user list available test");
            Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
            fixture.test.Log(LogStatus.Pass, "User list is available");
        }


        //[TearDown]
        //public override void Dispose()
        //{
        //    base.Dispose();
        //}
    }
}