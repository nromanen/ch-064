using System;
using Xunit;
using OnlineExam.Pages.POM;
using System.Threading;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;
using System.Linq;

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

                var tmp = courseManagment.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(courseName,firstBlock.GetCourseName());
                    //System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseName());
                    //System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseCreatinDate());
                }
                Thread.Sleep(1500);
            });
        }

        [Fact]
        public void CreateCourse_InvalidData()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CreateCourse_InvalidData");
                string courseName = String.Empty, courseDescription = "Description";

                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage().CreateCourse(courseName,courseDescription);
                var courseManagment = ConstructPage<CourseManagementPage>();

                var tmp = courseManagment.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    Assert.Null(firstBlock);
                   // System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseName());
                   // System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseCreatinDate());
                }
                Thread.Sleep(1500);
            });
        }

        /*[Fact]
        public void tmp()
        {
            fixture.test = fixture.extentReports.CreateTest("CreateCourse_InvalidData");
            string courseName = "C# Starter";

            var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
            var courseManagment = ConstructPage<CourseManagementPage>();

            var block = courseManagment.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseName());
                System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseCreatingDate());
                System.Windows.Forms.MessageBox.Show(firstBlock.courseName.GetAttribute("href"));
                if (firstBlock != null)
                {
                    firstBlock.ClickCourseLink();
                }
            }
            Thread.Sleep(3000);
        }*/

        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CreateCourse_InvalidData");
                string courseName = "Selenium .NET";

                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var tmp = courseView.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    //Assert.Null(firstBlock);
                    if (firstBlock != null && firstBlock.GetBtnDeleteText() != null)
                    {
                        firstBlock.ClickBtnDelete();
                    }
                }
                Thread.Sleep(1500);
            });

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
