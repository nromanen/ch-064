using System;
using Xunit;
using OnlineExam.Pages.POM;
using System.Threading;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Tests
{
    public class CourseTests : BaseTest
    {
        private readonly ITestOutputHelper output;

        public CourseTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        

        #region Delete test
        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            LoginAsTeacher();
            string CourseName = "NEW";
            var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            if (CourseMenegmentPage != null)
            {
                CourseMenegmentPage.MyCoursesBtn.Click();
            }

            var ViewCoursePage = ConstructPage<ViewCoursesPage>();
            if (ViewCoursePage != null)
            {
                ViewCoursePage.DeleteCourse(CourseName);
                Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
            }
        }
        #endregion

        #region Restore test
        [Fact]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            LoginAsTeacher();
            string CourseName = "NEW";
            var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            if (CourseMenegmentPage != null)
            {
                CourseMenegmentPage.MyCoursesBtn.Click();
            }

            var ViewCoursePage = ConstructPage<ViewCoursesPage>();
            if (ViewCoursePage != null)
            {
                Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
                ViewCoursePage.RestoreCourse(CourseName);
                Assert.True(ViewCoursePage.IsCourseRestored(CourseName));
            }
        }
        #endregion

        #region Change test (1 but this is fiasko bratan)
        [Fact]
        public void ChangeCourse_ShouldChangeCourseData()
        {
            //LoginAsTeacher();
            //string courseName = "NEW";
            //var courseMenegmentPage = ConstructPage<CourseManagementPage>();
            //if (courseMenegmentPage != null)
            //{
            //    courseMenegmentPage.MyCoursesBtn.Click();
            //}
            //var viewCoursePage = ConstructPage<ViewCoursesPage>();
            //if (viewCoursePage != null)
            //{
            //    //TODO: fix this shit with link
            //    var href = viewCoursePage.GetCourseLink(courseName);
            //    driver.Navigate().GoToUrl(href);
            //}

            //var editCoursePage = ConstructPage<CreateCoursePage>();
            //if (editCoursePage != null)
            //{
            //    var oldName = editCoursePage.GetName();
            //    var oldDescription = editCoursePage.GetDescription();
            //    string newName = "asda", newDescription = "asda";
            //    editCoursePage.EditCourse(newName, newDescription);
            //    editCoursePage.CourseOkBtn.Click();
            //    //TODO: fix this shit with link
            //    var newHref = viewCoursePage.GetCourseLink(newName);
            //    driver.Navigate().GoToUrl(newHref);
            //    Assert.Equal(newName, editCoursePage.GetName());
            //    Assert.Equal(newDescription, editCoursePage.GetDescription());
            //}
            throw new Exception("Rewrite using Page constructor");
        }
        #endregion

        #region Change course owner test
        [Fact]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            //LoginAsAdmin();
            //string CourseName = "C# Starter";
            //var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            //var tmp = CourseMenegmentPage.ChangeOwner(CourseName);
            //if (CourseMenegmentPage != null)
            //{
            //    //TODO: fix this shit
            //    driver.Navigate().GoToUrl(tmp);
            //}

            //var ChangeOwner = ConstructPage<ChangeCourseOwnerPage>();
            //if (ChangeOwner != null)
            //{
            //    string oldOwner = ChangeOwner.GetOwner();
            //    ChangeOwner.ChangeOwner();

            //    driver.Navigate().GoToUrl(tmp);
            //    string newOwner = ChangeOwner.GetOwner();
            //    Assert.NotEqual(oldOwner, newOwner);
            //}  
            throw new Exception("Rewrite using Page constructor");
        }
        #endregion

        [Fact]
        public void CheckTask_ShouldChangeTaskStatusToDone()
        {
            //TODO: Code review check  Tasks -> Solutions -> Review
        }

        public void LoginAsTeacher()
        {
            //Header header = new Header(driver);
            //LogInPage logInPage = header.GoToLogInPage();
            //logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            //var CourseMenu = new SideBar(driver).CoursesMenuItemClick();
            throw new Exception("Rewrite using Page constructor");
        }

        public void LoginAsAdmin()
        {
            //Header header = new Header(driver);
            //LogInPage logInPage = header.GoToLogInPage();
            //logInPage.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            //var CourseMenu = new SideBar(driver).CoursesMenuItemClick();
            throw new Exception("Rewrite using Page constructor");
        }
       

        //TODO: CODE page: Courses -> *Select course from list* -> *Select task from list* -> click START -> hello there

        //TODO: 1. Execute tests without Visual studio
        //TODO: 2. Generate report for Executed Tests
        //TODO: 3. Backup and Rollback DB in tests 
    }
}
