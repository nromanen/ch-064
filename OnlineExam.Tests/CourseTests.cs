using System;
using Xunit;
using OnlineExam.Pages.POM;
using System.Threading;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Tests
{
    public class CourseTests : BaseTest, IDisposable
    {
        private readonly ITestOutputHelper output;

        public CourseTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        #region Create tests 2
        [Fact]
        public void CreateCourse_ShouldCreateCourse()
        {
            LoginAsTeacher();
            string Title = "Title1", Description = "Description1";
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.AddCourseBtn.Click();
            var CreateCoursePage = new CreateCoursePage(driver);

            CreateCoursePage.FillCourse(Title, Description);
            Assert.Equal(Title, CreateCoursePage.GetName());
            Assert.Equal(Description, CreateCoursePage.GetDescription());

            CreateCoursePage.CourseOkBtn.Click();
            Assert.True(CourseMenegmentPage.IsExist(Title));
        }

        [Fact]
        public void CreateCourse_ErrorMessageShouldAppear()
        {
            LoginAsTeacher();
            string Title = String.Empty, Description = "Description1";
            var expectedURL = "http://localhost:55842/CourseManagement/Create";
            
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.AddCourseBtn.Click();
            var CreateCoursePage = new CreateCoursePage(driver);

            CreateCoursePage.FillCourse(Title, Description);
            Assert.Equal(Title, CreateCoursePage.GetName());
            Assert.Equal(Description, CreateCoursePage.GetDescription());

            CreateCoursePage.CourseOkBtn.Click();
            Thread.Sleep(2000);

            string actualURL = driver.Url;
            Assert.Equal(expectedURL,actualURL);
        }
        #endregion

        #region Delete test 1
        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            LoginAsTeacher();
            string CourseName = "Title1";
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.MyCoursesBtn.Click();
            var ViewCoursePage = new ViewCoursesPage(driver);
            ViewCoursePage.DeleteCourse(CourseName);
            Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
        }
        #endregion

        #region Restore test 1
        [Fact]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string CourseName = "Title1";
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.MyCoursesBtn.Click();
            var ViewCoursePage = new ViewCoursesPage(driver);
            Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
            ViewCoursePage.RestoreCourse(CourseName);
            Assert.True(ViewCoursePage.IsCourseRestored(CourseName));
        }
        #endregion

        #region Change test (1 but this is fiasko bratan)
        [Fact]
        public void ChangeCourse_ShouldChangeCourseData()
        {
            LoginAsTeacher();
            string courseName = "NEW";
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.MyCoursesBtn.Click();
            var viewCoursePage = new ViewCoursesPage(driver);
            //TODO: fix this shit with link
            var href = viewCoursePage.GetCourseLink(courseName);
            driver.Navigate().GoToUrl(href);
            var editCoursePage = new CreateCoursePage(driver);
            var oldName = editCoursePage.GetName();
            var oldDescription = editCoursePage.GetDescription();
            string newName = "asda", newDescription = "asda";
            editCoursePage.EditCourse(newName, newDescription);
            editCoursePage.CourseOkBtn.Click();
            //TODO: fix this shit with link
            var newHref = viewCoursePage.GetCourseLink(newName);
            driver.Navigate().GoToUrl(newHref);
            Assert.Equal(newName,editCoursePage.GetName());
            Assert.Equal(newDescription, editCoursePage.GetDescription());
            Thread.Sleep(3000);
        }
        #endregion

        #region Change course owner test 1
        [Fact]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            LoginAsAdmin();
            string CourseName = "C# Starter";
            var CourseMenegmentPage = new CourseManagementPage(driver);
            
            var tmp = CourseMenegmentPage.ChangeOwner(CourseName);
            //TODO: fix this shit
            driver.Navigate().GoToUrl(tmp);
            var ChangeOwner = new ChangeCourseOwnerPage(driver);
            string oldOwner = ChangeOwner.GetOwner();
            ChangeOwner.ChangeOwner();
            
            driver.Navigate().GoToUrl(tmp);
            string newOwner = ChangeOwner.GetOwner();
            Assert.NotEqual(oldOwner,newOwner);
        }
        #endregion

        [Fact]
        public void CheckTask_ShouldChangeTaskStatusToDone()
        {
            //TODO: Code review check  Tasks -> Solutions -> Review
        }

        public void LoginAsTeacher()
        {
            Header header = new Header(driver);
            LogInPage logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var CourseMenu = new SideBar(driver).CoursesMenuItemClick();
        }

        public void LoginAsAdmin()
        {
            Header header = new Header(driver);
            LogInPage logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var CourseMenu = new SideBar(driver).CoursesMenuItemClick();
        }
       

        //TODO: CODE page: Courses -> *Select course from list* -> *Select task from list* -> click START -> hello there

        //TODO: 1. Execute tests without Visual studio
        //TODO: 2. Generate report for Executed Tests
        //TODO: 3. Backup and Rollback DB in tests

        
    }
}
