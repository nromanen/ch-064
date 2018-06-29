using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    public class ChangeNameTest : BaseTest
    {


        [Fact]
        public void TestChangeName()
        {
            BeginTest();
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = new LogInPage(driver);
            var indexPage = loginPage.SignIn("student@gmail.com", Constants.STUDENT_PASSWORD);
            var header = new Header(driver);
            var userInfo = header.GoToUserAccountPage();
            var changeNamePage = userInfo.OpenChangeNamePage();

            changeNamePage.SetNewName("studentTEST", Constants.STUDENT_PASSWORD);
            changeNamePage.SaveNewName();

            header = new Header(driver);
            var newUserName = header.GetHeaderUserName();
            var isEqual = String.Equals("studentTEST", newUserName, StringComparison.InvariantCultureIgnoreCase);
            Assert.True(isEqual);
        }

    }
}
