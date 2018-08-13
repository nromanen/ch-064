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
            var TEST_DATA = Framework.Params.ParametersResolver.Resolve<Framework.Params.CreateCourseParams>("CreateCourseData.json");
            
            LoginAsTeacher();
            string courseName = TEST_DATA.Title, courseDescr = TEST_DATA.Description;
            var courseManagmentPage = ConstructPage<CourseManagementPage>();

            TestContext.Out.WriteLine("Click on 'Add course' button.");
            courseManagmentPage.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();

            TestContext.Out.WriteLine($"Creating course with title: {courseName} and description: {courseDescr}.");
            createCourse.FillCourse(courseName, courseDescr);

            TestContext.Out.WriteLine("Click 'Ok' button.");
            createCourse.ClickBtnOk();

            bool isCourseCreated = courseManagmentPage.IsCourseCreated(courseName);
            Assert.IsTrue(isCourseCreated, $"Test fail because course with '{courseName}' title is not presented in course list.");
            TestContext.Out.WriteLine($"Course with title '{courseName}' is successfully created.");
        }

        [Test]
        public void CreateCourse_InvalidData()
        {
            LoginAsTeacher();
            string courseName = String.Empty, courseDescr = string.Empty;
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Out.WriteLine("Click on 'Add course' button");
            courseManagment.ClickBtnAddCourse();
            var createCourse = ConstructPage<CreateCoursePage>();
            string expectedURL = createCourse.GetCurrentUrl();

            TestContext.Out.WriteLine($"Creating course with empty title and description.");
            createCourse.FillCourse(courseName, courseDescr);

            TestContext.Out.WriteLine("Click 'Ok' button.");
            createCourse.ClickBtnOk();
            string currentURL = createCourse.GetCurrentUrl();
            Assert.AreEqual(expectedURL, currentURL, $"Test fail because expected URL: {expectedURL} is not equal to current URL: {currentURL}");
        }

        [Test]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            var TEST_DATA = Framework.Params.ParametersResolver.Resolve<Framework.Params.DeleteCourseParams>("DeleteCourseData.json");

            LoginAsTeacher();
            string courseName = TEST_DATA.Title;
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Out.WriteLine("Click 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();
            
            TestContext.Out.WriteLine($"Deleting course with title: {courseName}.");
            var IsCourseDeleted = courseView.IsDeleted(courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnRecoverCourse");
            Assert.IsNotNull(IsCourseDeleted, $"Could not delete course '{courseName}' because it was already deleted.");
            TestContext.Out.WriteLine($"Course with title '{courseName}' is successfully deleted.");
        }

        [Test]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string courseName = "CLR example";
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Out.WriteLine("Click on 'My courses' button");
            courseManagment.ClickBtnMyCourses();
            var courseView = ConstructPage<ViewCoursesPage>();

            TestContext.Out.WriteLine($"Restoring course with title: {courseName}.");
            string text = courseView.IsRestored(courseView, courseName, resxManager);
            string btnRecoverCourseText = resxManager.GetString("btnDeleteCourse");
            Assert.AreEqual(btnRecoverCourseText, text, $"Could not restore course because expect button'{btnRecoverCourseText}', but found button '{text}'.");
            TestContext.Out.WriteLine($"Course with title '{courseName}' is successfully restored.");
        }

        [Test]
        public void EditCourse_ShouldChangeCourseData()
        {
            var TEST_DATA = Framework.Params.ParametersResolver.Resolve<Framework.Params.EditCourseParams>("EditCourseData.json");

            LoginAsTeacher();
            string courseName = TEST_DATA.pastTitle, newCourseName = TEST_DATA.presentTitle;
            var courseManagment = ConstructPage<CourseManagementPage>();

            TestContext.Out.WriteLine("Click on 'My courses' button.");
            courseManagment.ClickBtnMyCourses();
            var courseViewPage = ConstructPage<ViewCoursesPage>();

            TestContext.Out.WriteLine("Click on 'Change' button.");
            courseViewPage.ClickChangeBtn(courseName);
            var editPage = ConstructPage<CreateCoursePage>();

            TestContext.Out.WriteLine($"Change to ");
            editPage.EditCourse(newCourseName, TEST_DATA.presentDescription);

            TestContext.Out.WriteLine("Click on 'Ok' button.");
            editPage.ClickBtnOk();

            bool isCourseExist = courseViewPage.IsCourseExist(newCourseName);
            Assert.True(isCourseExist, $"Could not found course with title: {newCourseName}.");
            TestContext.Out.WriteLine($"Title of '{courseName}' course successfully changed to '{newCourseName}'.");
        }

        [Test]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            LoginAsAdmin();
            string courseName = "Owner";
            string owner = String.Empty;
            var courseViewPage = ConstructPage<ViewCoursesPage>();

            TestContext.Out.WriteLine("Click on 'Change owner' button.");
            courseViewPage.ClickChangeOwnerBtn(courseName);
            var changeOwnerPage = ConstructPage<ChangeCourseOwnerPage>();
            string pastOwner = changeOwnerPage.GetOwnerName(resxManager);
            TestContext.Out.WriteLine($"Current owner: {pastOwner}.");

            TestContext.Out.WriteLine($"Changing current owner: {pastOwner}.");
            changeOwnerPage.ChangeOwner(resxManager);
            courseViewPage.ClickChangeOwnerBtn(courseName);

            string presentOwner = changeOwnerPage.GetOwnerName(resxManager);
            TestContext.Out.WriteLine($"Get new owner: {presentOwner}.");
            Assert.AreNotEqual(pastOwner, presentOwner, $"The owner has not changed. Past owner = '{pastOwner}', present owner = '{presentOwner}'");
            TestContext.Out.WriteLine($"Owner successfully changed from '{pastOwner}' to '{presentOwner}'.");
        }

        public void LoginAsTeacher()
        {
            TestContext.Out.WriteLine($"SignIn as teacher using email: {Constants.TEACHER_EMAIL}, password: {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        public void LoginAsAdmin()
        {
            TestContext.Out.WriteLine($"SignIn as admin using email: {Constants.ADMIN_EMAIL}, password: {Constants.ADMIN_PASSWORD}");
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }
    }
}
