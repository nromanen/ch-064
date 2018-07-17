using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AventStack.ExtentReports;
using OnlineExam.Framework;
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
        public void CreateNewsTest()
        {
            UITest(() =>
            {
                var signIn = header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
                var result = newsPage.CreateArticle();
                Assert.True(result.UrlEndsWith("AddNews/News"));
            });
        }

    }
}
