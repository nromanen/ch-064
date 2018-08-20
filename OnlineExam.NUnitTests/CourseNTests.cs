using System;
using System.Threading;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;

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
            var TEST_DATA = ParametersResolver.Resolve<Framework.Params.CreateCourseParams>("CreateCourseData.json");

            LoginAsTeacher();
            string courseName = TEST_DATA.Title, courseDescr = TEST_DATA.Description;
            var courseManagmentPage = ConstructPage<CourseManagementPage>();

            LogProgress("Click on 'Add course' button.");
            courseManagmentPage.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();

            LogProgress($"Creating course with title: {courseName} and description: {courseDescr}.");
            createCourse.FillCourse(courseName, courseDescr);

            LogProgress("Click 'Ok' button.");
            createCourse.ClickBtnOk();

            bool isCourseCreated = courseManagmentPage.IsCourseCreated(courseName);
            Assert.IsTrue(isCourseCreated, $"Test fail because course with '{courseName}' title is not presented in course list.");
            LogProgress($"Course with title '{courseName}' is successfully created.");
        }

        [Test]
        public void CreateCourse_InvalidData()
        {
            LoginAsTeacher();
            string courseName = String.Empty, courseDescr = string.Empty;
            var courseManagment = ConstructPage<CourseManagementPage>();

            LogProgress("Click on 'Add course' button");
            courseManagment.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();
            string expectedURL = createCourse.GetCurrentUrl();

            LogProgress($"Creating course with empty title and description.");
            createCourse.FillCourse(courseName, courseDescr);

            LogProgress("Click 'Ok' button.");
            createCourse.ClickBtnOk();
            string currentURL = createCourse.GetCurrentUrl();
            Assert.AreEqual(expectedURL, currentURL, $"Test fail because expected URL: {expectedURL} is not equal to current URL: {currentURL}");
        }

        [Test]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            var TEST_DATA = ParametersResolver.Resolve<Framework.Params.DeleteCourseParams>("DeleteCourseData.json");

            LoginAsTeacher();
            string courseName = TEST_DATA.Title;
            var courseManagment = ConstructPage<CourseManagementPage>();

            LogProgress("Click 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();

            LogProgress($"Deleting course with title: {courseName}.");
            var IsCourseDeleted = courseView.IsDeleted(courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnRecoverCourse");
            Assert.IsNotNull(IsCourseDeleted, $"Could not delete course '{courseName}' because it was already deleted.");
            LogProgress($"Course with title '{courseName}' is successfully deleted.");
        }

        [Test]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string courseName = "CLR example";
            var courseManagment = ConstructPage<CourseManagementPage>();

            LogProgress("Click on 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();

            LogProgress($"Restoring course with title: {courseName}.");
            string text = courseView.IsRestored(courseView, courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnDeleteCourse");
            Assert.AreEqual(btnRecoverCourseText, text, $"Could not restore course because expect button'{btnRecoverCourseText}', but found button '{text}'.");
            LogProgress($"Course with title '{courseName}' is successfully restored.");
        }

        [Test]
        public void EditCourse_ShouldChangeCourseData()
        {
            var TEST_DATA = ParametersResolver.Resolve<Framework.Params.EditCourseParams>("EditCourseData.json");

            LoginAsTeacher();
            string courseName = TEST_DATA.pastTitle, newCourseName = TEST_DATA.presentTitle;
            var courseManagment = ConstructPage<CourseManagementPage>();

            LogProgress("Click on 'My courses' button.");
            courseManagment.ClickBtnMyCourses();
            var courseViewPage = ConstructPage<ViewCoursesPage>();

            LogProgress("Click on 'Change' button.");
            courseViewPage.ClickChangeBtn(courseName);
            var editPage = ConstructPage<CreateCoursePage>();

            LogProgress($"Change to ");
            editPage.EditCourse(newCourseName, TEST_DATA.presentDescription);

            LogProgress("Click on 'Ok' button.");
            editPage.ClickBtnOk();

            bool isCourseExist = courseViewPage.IsCourseExist(newCourseName);
            Assert.True(isCourseExist, $"Could not found course with title: {newCourseName}.");
            LogProgress($"Title of '{courseName}' course successfully changed to '{newCourseName}'.");
        }

        [Test]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            LoginAsAdmin();
            string courseName = "Owner";
            string owner = String.Empty;
            var courseViewPage = ConstructPage<ViewCoursesPage>();

            LogProgress("Click on 'Change owner' button.");
            courseViewPage.ClickChangeOwnerBtn(courseName);
            var changeOwnerPage = ConstructPage<ChangeCourseOwnerPage>();
            string pastOwner = changeOwnerPage.GetOwnerName(resxManager);
            LogProgress($"Current owner: {pastOwner}.");

            LogProgress($"Changing current owner: {pastOwner}.");
            changeOwnerPage.ChangeOwner(resxManager);
            courseViewPage.ClickChangeOwnerBtn(courseName);

            string presentOwner = changeOwnerPage.GetOwnerName(resxManager);
            LogProgress($"Get new owner: {presentOwner}.");
            Assert.AreNotEqual(pastOwner, presentOwner, $"The owner has not changed. Past owner = '{pastOwner}', present owner = '{presentOwner}'");
            LogProgress($"Owner successfully changed from '{pastOwner}' to '{presentOwner}'.");
        }

        public void LoginAsTeacher()
        {
            LogProgress($"SignIn as teacher using email: {Constants.TEACHER_EMAIL}, password: {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        public void LoginAsAdmin()
        {
            LogProgress($"SignIn as admin using email: {Constants.ADMIN_EMAIL}, password: {Constants.ADMIN_PASSWORD}");
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }
    }
}