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
    [Parallelizable(ParallelScope.Self)]
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
            TestContext.Out.WriteLine("\n<br> " + "Done base set up");
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CreateNewsTest()
        {
            var signIn = header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            TestContext.Out.WriteLine("\n<br> " + $"Signed in as {Constants.TEACHER_EMAIL}.");
            var newsPage = ConstructPage<SideBar>().GoToTeacherNewsPage();
            TestContext.Out.WriteLine("\n<br> " + "Opened news page.");
            var createArticle = newsPage.CreateArticle();
            TestContext.Out.WriteLine("\n<br> " + "Article created.");
            var result = createArticle.UrlEndsWith("AddNews/News");
            Assert.True(result, "News page doesn't return. News article isn't created.");
        }
    }
}
