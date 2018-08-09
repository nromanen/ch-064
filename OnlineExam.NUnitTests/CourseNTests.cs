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
            var courseManagmentPage = ConstructPage<CourseManagementPage>();

            TestContext.Progress.WriteLine("Click on 'Add course' button.");
            courseManagmentPage.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();

            TestContext.Progress.WriteLine($"Creating course with title: {courseName} and description: {courseDescr}.");
            createCourse.FillCourse(courseName, courseDescr);

            TestContext.Progress.WriteLine("Click 'Ok' button.");
            createCourse.ClickBtnOk();

            bool isCourseCreated = courseManagmentPage.IsCourseCreated(courseName);
            Assert.IsTrue(isCourseCreated, $"Test fail because course with '{courseName}' title is not presented in course list.");
            TestContext.Progress.WriteLine($"Course with title '{courseName}' is successfully created.");
        }

        [Test]
        public void CreateCourse_InvalidData()
        {
            LoginAsTeacher();
            string courseName = String.Empty, courseDescr = string.Empty;
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Progress.WriteLine("Click on 'Add course' button");
            courseManagment.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();
            string expectedURL = createCourse.GetCurrentUrl();

            TestContext.Progress.WriteLine($"Creating course with title: {courseName} and description: {courseDescr}.");
            createCourse.FillCourse(courseName, courseDescr);

            TestContext.Progress.WriteLine("Click 'Ok' button.");
            createCourse.ClickBtnOk();
            string currentURL = createCourse.GetCurrentUrl();
            Assert.AreEqual(expectedURL, currentURL, $"Test fail because expected URL: {expectedURL} is not equal to current URL: {currentURL}");
        }

        [Test]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            LoginAsTeacher();
            string courseName = "Selenium";
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Progress.WriteLine("Click 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();

            TestContext.Progress.WriteLine($"Deleting course with title: {courseName}.");
            var IsCourseDeleted = courseView.IsDeleted(courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnRecoverCourse");
            Assert.IsNotNull(IsCourseDeleted, $"Could not delete course '{courseName}' because it was already deleted.");
        }

        [Test]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string courseName = "CLR example";
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Progress.WriteLine("Click on 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();

            TestContext.Progress.WriteLine($"Restoring course with title: {courseName}.");
            string text = courseView.IsRestored(courseView, courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnRecoverCourse");
            Assert.AreEqual(btnRecoverCourseText, text, $"Could not restore course because expect button'{btnRecoverCourseText}', but found button '{text}'.");
        }

        [Test]
        public void EditCourse_ShouldChangeCourseData()
        {
            LoginAsTeacher();
            string courseName = "ChangeMe", newCourseName = "WebDriver";
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Progress.WriteLine("Click on 'My courses' button.");
            courseManagment.ClickBtnMyCourses();
            var courseViewPage = ConstructPage<ViewCoursesPage>();

            TestContext.Progress.WriteLine("Click on 'Change' button.");
            courseViewPage.ClickChangeBtn(courseName);
            var editPage = ConstructPage<CreateCoursePage>();

            TestContext.Progress.WriteLine($"Change to ");
            editPage.EditCourse(newCourseName, "New Description");

            TestContext.Progress.WriteLine("Click on 'Ok' button.");
            editPage.ClickBtnOk();

            bool isCourseExist = courseViewPage.IsCourseExist(newCourseName);
            Assert.True(isCourseExist, $"Could not found course with title: {newCourseName}.");
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
                    TestContext.Progress.WriteLine("Click on 'Change owner' button.");
                    singleBlock.ClickBtnChangeOwner();
                    var changeOwnerPage = ConstructPage<ChangeCourseOwnerPage>();
                    owner = changeOwnerPage.GetOwnerName();

                    TestContext.Progress.WriteLine($"Changing current owner: {owner}.");
                    changeOwnerPage.ChangeOwner();
                    bool IsOwnerChanges = changeOwnerPage.IsOwnerChanges(courseView, owner);
                    Assert.True(IsOwnerChanges, "Owner is not changed");
                }
            }
        }

        public void LoginAsTeacher()
        {
            TestContext.Progress.WriteLine($"SignIn as teacher using email: {Constants.TEACHER_EMAIL}, password: {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        public void LoginAsAdmin()
        {
            TestContext.Progress.WriteLine($"SignIn as admin using email: {Constants.ADMIN_EMAIL}, password: {Constants.ADMIN_PASSWORD}");
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }
    }
}
