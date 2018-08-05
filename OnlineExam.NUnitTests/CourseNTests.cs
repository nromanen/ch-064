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
using System.Globalization;
using System.Resources;


namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [Category("Basic")]
    [TestFixture]
    public class CourseNTests : BaseNTest
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
        }
        
        [Test]
        public void CreateCourse_ValidData()
        {
            LoginAsTeacher();
            string courseName = "Console class", courseDescr = "Description";
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnAddCourse.Click();
            var createCourse = ConstructPage<CreateCoursePage>();
            createCourse.FillCourse(courseName, courseDescr);
            createCourse.BtnOk.Click();
            var blockList = courseManagment.GetBlocks();
            var name = courseManagment.GetCreatedCourseName(blockList, courseName);
            Assert.AreEqual(courseName, name);
        }

        [Test]
        public void CreateCourse_InvalidData()
        {
            LoginAsTeacher();
            string courseName = String.Empty, courseDescr = string.Empty;
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnAddCourse.Click();
            var createCourse = ConstructPage<CreateCoursePage>();
            string expectedURL = createCourse.GetCurrentUrl();
            createCourse.FillCourse(courseName, courseDescr);
            createCourse.BtnOk.Click();
            string currentURL = createCourse.GetCurrentUrl();
            Assert.AreEqual(expectedURL, currentURL);
        }

        [Test]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            LoginAsTeacher();
            string courseName = "Selenium";
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnMyCourses.Click();
            var courseView = ConstructPage<ViewCoursesPage>();
            var text = courseView.IsDeleted(courseView,courseName,resxManager);
            Assert.AreEqual(resxManager.GetString("btnRecoverCourse"), text);
        }

        [Test]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string courseName = "CLR example";
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnMyCourses.Click();
            var courseView = ConstructPage<ViewCoursesPage>();
            var text = courseView.IsRestored(courseView, courseName,resxManager);
            Assert.AreEqual(resxManager.GetString("btnDeleteCourse"), text);
        }

        [Test]
        public void EditCourse_ShouldChangeCourseData()
        {
            LoginAsTeacher();
            string courseName = "ChangeMe", newCourseName = "WebDriver";
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnMyCourses.Click();
            var courseView = ConstructPage<ViewCoursesPage>();
            var blockList = courseView.GetBlocks();
            if (blockList != null)
            {
                var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (singleBlock != null)
                {
                    singleBlock.ClickBtnChange();
                    var editPage = ConstructPage<CreateCoursePage>();
                    editPage.EditCourse(newCourseName, "New Description");
                    editPage.BtnOk.Click();
                    Assert.True(singleBlock.IsCourseExist(courseName, newCourseName, courseView));
                }
            }  
        }

        [Test]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            LoginAsAdmin();
            string courseName = "Owner";
            string owner = String.Empty;
            
            var courseManagment = ConstructPage<CourseManagementPage>();
            var courseView = ConstructPage<ViewCoursesPage>();
            var blockList = courseView.GetBlocks();

            if (blockList != null)
            {
                var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (singleBlock != null)
                {
                    singleBlock.ClickBtnChangeOwner();
                    var changeOwnerPage = ConstructPage<ChangeCourseOwnerPage>();
                    owner = changeOwnerPage.GetOwnerName();
                    changeOwnerPage.ChangeOwner();
                    Assert.True(changeOwnerPage.IsOwnerChanges(courseView,owner));
                }
            }
        }
        
        public void LoginAsTeacher()
        {
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        public void LoginAsAdmin()
        {
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }
    }
}
