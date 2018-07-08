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
    [Collection("MyTestCollection")]
    public class NewsTest : BaseTest
    {
        public NewsTest()
        {
        }

        [Fact]
        public void CheckIfNewsArePresent()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                var signInAsStudent = logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                driver.RefreshPage();
                var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
                Assert.True(newsPage.IsNewsPresentedInNewsList("C# Starter"));
            });
        }

        [Fact]
        public void CreateNewsTest()
        {
            UITest(() =>
            {
                BeginTest();
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                var signIn = logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
                var result = newsPage.CreateArticle();
                Assert.True(result.UrlEndsWith("AddNews/News"));
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
