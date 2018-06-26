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
    public class AdminTest : BaseTest, IDisposable
    {
        public AdminTest()
        {
        }

        [Fact]
        public void DeleteUserTest()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(ADMIN_EMAIL, ADMIN_PASSWORD);
            var adminPanelPage = new SideBar(driver).AdminPanelMenuItemClick();
            Assert.True(adminPanelPage.IsUserPresentedInUserList("viktor@gmail.com"),"User is not presented in the system," +
                                                                                     "so we have not opportunity to delete this user");
            adminPanelPage.DeleteUser("viktor@gmail.com");
            Assert.False(adminPanelPage.IsUserPresentedInUserList("viktor@gmail.com"),"Error");

        }
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}