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
            var loginPage = ConstructPage<LogInPage>();
            var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            var header = ConstructPage<Header>();
            var userInfo = header.GoToUserAccountPage();
            var changeNamePage = userInfo.OpenChangeNamePage();

            changeNamePage.SetNewName("student3@gmail.com", Constants.STUDENT_PASSWORD);
            changeNamePage.SaveNewName();

            header = ConstructPage<Header>();
            var newUserName = header.GetHeaderUserName();
            var isEqual = String.Equals("student3@gmail.com", newUserName, StringComparison.InvariantCultureIgnoreCase);
            Assert.True(isEqual);
        }

    }
}
