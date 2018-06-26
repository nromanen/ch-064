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
            var logInPage = new LogInPage(driver);
            logInPage.SignIn(ADMIN_EMAIL, ADMIN_PASSWORD);
            var adminPanelPage = new SideBar(driver).AdminPanelMenuItemClick();
            adminPanelPage.DeleteUser("viktor@gmail.com");

        }
        public void Dispose()
        {
            driver.Dispose();
        }
    }
}