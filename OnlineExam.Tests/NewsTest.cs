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
        public void CheckIfNewsArePresent()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            var signInAsStudent = logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().Refresh();
            var newsPage = ConstructPage<SideBar>().NewsMenuItemClick();
            Assert.True(newsPage.IsNewsPresentedInNewsList("C# Starter"));
        }

        [Fact]
        public void CreateNewsTest()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            var signIn = logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var newsPage = ConstructPage<SideBar>().NewsMenuItemClick();
            var result = newsPage.CreateArticle();
            Assert.StartsWith(result.ToString(), "OnlineExam.Pages.POM.TeacherNewsPage");
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
