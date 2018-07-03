using System;
using System.Collections.Generic;
using System.IO;
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
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            var signInAsStudent = logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().Refresh();
            var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            Assert.True(newsPage.IsNewsPresentedInNewsList("C# Starter"));
        }

        [Fact]
        public void CreateNewsTest()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            var signIn = logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            Thread.Sleep(1000);
            var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
            Thread.Sleep(1000);
            var result = newsPage.CreateArticle();
            Thread.Sleep(1000);
            Assert.StartsWith(result.ToString(), "An unhandled exception occurred while processing the request.");

        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
