using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OnlineExam.DatabaseHelper;


namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class CourseNTests: BaseNTest
    {
        private Header header;
        private LogInPage logInPage;
        private CourseManagementPage adminPanelPage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        [Test]
        public void CreateCourse_ValidData()
        {
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnAddCourse.Click();
            var createCourse = ConstructPage<CreateCoursePage>();
            createCourse.FillCourse("tmp11","tmp1");
            createCourse.BtnOk.Click();
            
            Thread.Sleep(2000);
        }

        [Test]
        public void CreateCourse_InvalidData()
        {
            DataModel tmp = new DataModel();
        }
    }
}
