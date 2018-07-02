using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    public class NewsTest : BaseTest, IDisposable
    {
        public NewsTest()
        {
        }

        [Fact]
        public void ReferencesExistTests()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            var signInAsStudent = logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().Refresh();
            var newsPage = new SideBar(driver).NewsMenuItemClick();

            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
          //  Assert.True(newsPage.IsLinkPresentedInNewsPage("C# Starter"));
        }

        [Fact]
        public void CreateNewsTest()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            var signIn = logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            Thread.Sleep(1000);
            var teacherNewsPage = new SideBar(driver).NewsMenuItemClick();
            Thread.Sleep(1000);
            teacherNewsPage.CreateArticle();
         //   Assert.True(teacherNewsPage.IsNewsPresentedInNewsList("Title"));

        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
