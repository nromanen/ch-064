using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Xunit;

namespace OnlineExam.Tests
{
    public class LoginTest : BaseTest, IDisposable
    {
        LoginTest()
        {
        }

        [Fact]
        public void SignInTest()
        {
            LogInPage logIn = new LogInPage(driver);
            var result = logIn.SignIn("student@gmail.com", "Student_123");
          //  Assert.Equal(new IndexPage, result);
        }

        [Fact]
        public void SignOutTest()
        {
            LogInPage logIn = new LogInPage(driver);
            logIn.SignIn("student@gmail.com", "Student_123");
            Header header = new Header(driver);
            var result = header.SignOut();
         //   Assert.Contains(userAccountManageLinkElement, header);
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
