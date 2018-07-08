using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace OnlineExam.Tests
{
    public class AdminTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private AdminPanelPage adminPanelPage;

        public AdminTest()
        {
            //header = new Header(driver);
            //logInPage = header.GoToLogInPage();
            //logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            //adminPanelPage = new SideBar(driver).AdminPanelMenuItemClick();
            throw new Exception("Rewrite using Page constructor");
        }

        [Fact]
        public void IsUserPresentedInUserListTest()
        {
           Assert.True(adminPanelPage.IsUserPresentedInUserList(""));
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
        }

        [Fact]
        public void ChangeUserRole()
        {
            var changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            changeRolePage.ChangeRole(Constants.TEACHER);
            changeRolePage = adminPanelPage.ChangeRoleOfUserButtonClick(Constants.VIKTOR_EMAIL);
            Assert.Equal(Constants.STUDENT,changeRolePage.CurrentRole());
        }

       
    }
}