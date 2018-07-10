using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class NewsTest : BaseTest
    {
        private Header header;
        private SideBar sideBar;

        public NewsTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Fact]
        public void CheckIfNewsArePresent()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CheckIfNewsArePresent");
                var signInAsStudent = header.GoToLogInPage().SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                driver.RefreshPage();
                var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
                Assert.True(newsPage.IsNewsPresentedInNewsList("C# Starter"));
                fixture.test.Log(Status.Pass, "News Are Present.");
            });
        }

        [Fact]
        public void CreateNewsTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CreateNewsTest");
                var signIn = header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
                var result = newsPage.CreateArticle();
                Assert.True(result.UrlEndsWith("AddNews/News"));
                fixture.test.Log(Status.Pass, "News Created.");
                RollbackDatabase();
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
