using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using Xunit;

namespace OnlineExam.Tests
{
    public class AdminTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private AdminPanelPage adminPanelPage;
        private ExtentReports extent;
        private ExtentTest test;

        public AdminTest()
        {
            extent = new ExtentReports(@"E:\SS\report.html",false);
            test = extent.StartTest("Admin test", "description");
            BeginTest();
            header = new Header(driver);
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = new SideBar(driver).GoToAdminPanelPage();
        }

        [Fact]
        public void IsUserPresentedInUserListTest()
        {
            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.STUDENT_EMAIL));
            test.Log(LogStatus.Pass, "User is presented in user list");
        }

        [Fact]
        public void DeleteUserTest()
        {
            Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.VIKTOR_EMAIL),
                "User is not presented in the system," +
                "so we have not opportunity to delete this user");
            adminPanelPage.DeleteUser(Constants.VIKTOR_EMAIL);
            Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
            Assert.False(adminPanelPage.IsUserPresentedInUserList(Constants.VIKTOR_EMAIL), "Error");
            test.Log(LogStatus.Pass, "User is deleted successfully");

        }

        [Fact]
        public void ChangeUserRoleTest()
        {
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            changeRolePage.ChangeRole(Constants.TEACHER);
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            Assert.Equal(Constants.TEACHER, changeRolePage.CurrentRole());
            test.Log(LogStatus.Pass, "Role is changed successfully");
        }

        [Fact]
        public void IsUserListAvailable()
        {
            Assert.True(adminPanelPage.IsListOfUsersH2ElementPresented());
            test.Log(LogStatus.Pass,"User list is available");
        }

        public override void Dispose()
        {
            // ending test
            extent.EndTest(test);
            // Flush test
            extent.Flush();
            base.Dispose();
        }
    }
}