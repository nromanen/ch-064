using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    //[Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Basic")]
    public class NewsNTest : BaseNTest
    {
        private Header header;
        private SideBar sideBar;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CreateNewsTest()
        {
            var signIn = header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
            var result = newsPage.CreateArticle();
            Assert.True(result.UrlEndsWith("AddNews/News"));
        }
    }
}
