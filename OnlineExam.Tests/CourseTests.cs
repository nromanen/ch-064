using System;
using Xunit;
using OnlineExam.Pages.POM;
using System.Threading;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class CourseTests : BaseTest
    {
        private Framework.DatabaseHelper helper;
        public CourseTests(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
        }
        
        [Fact]
        public void CreateCourse_ValidData()
        {
            UITest(() =>
            {
                string courseName = ".NET FRAMEWORK", courseDescription = "Nice description";
                fixture.test = fixture.extentReports.CreateTest("CreateCourse_ValidData");

                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage().CreateCourse(courseName, courseDescription);
                var courseManagment = ConstructPage<CourseManagementPage>();

                Assert.True(courseManagment.IsExist(courseName));
                Thread.Sleep(1500);
            });
        }


        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            /*LoginAsTeacher();
            string CourseName = "NEW";
            var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            if (CourseMenegmentPage != null)
            {
              //  CourseMenegmentPage.MyCoursesBtn.Click();
            }

            var ViewCoursePage = ConstructPage<ViewCoursesPage>();
            if (ViewCoursePage != null)
            {
                ViewCoursePage.DeleteCourse(CourseName);
                Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
            }*/
        }



        [Fact]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            /*
            string CourseName = "NEW";
            var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            if (CourseMenegmentPage != null)
            {
                //CourseMenegmentPage.MyCoursesBtn.Click();
            }

            var ViewCoursePage = ConstructPage<ViewCoursesPage>();
            if (ViewCoursePage != null)
            {
                Assert.True(ViewCoursePage.IsCourseDeleted(CourseName));
                ViewCoursePage.RestoreCourse(CourseName);
                Assert.True(ViewCoursePage.IsCourseRestored(CourseName));
            }*/
        }



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
            //    
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
            //    
            //    var newHref = viewCoursePage.GetCourseLink(newName);
            //    driver.Navigate().GoToUrl(newHref);
            //    Assert.Equal(newName, editCoursePage.GetName());
            //    Assert.Equal(newDescription, editCoursePage.GetDescription());
            //}
            throw new Exception("Rewrite using Page constructor");
        }



        [Fact]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            //LoginAsAdmin();
            //string CourseName = "C# Starter";
            //var CourseMenegmentPage = ConstructPage<CourseManagementPage>();
            //var tmp = CourseMenegmentPage.ChangeOwner(CourseName);
            //if (CourseMenegmentPage != null)
            //{
            //    
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
    }
}
