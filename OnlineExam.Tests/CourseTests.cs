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
        public CourseTests(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
        }
        
        [Fact]
        public void CreateCourse_ValidData()
        {
            UITest(() =>
            {
                string courseName = ".NET FRAMEWORK", courseDescription = "Description";
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
                }
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
                }
            });
        }

        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("DeleteCourse_ShouldDeleteCourse");
                string courseName = "Selenium";
                bool flag = false;
                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var tmp = courseView.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));                
                    if (firstBlock != null && (firstBlock.GetBtnDeleteText().Equals("Delete") || firstBlock.GetBtnDeleteText().Equals("Видалити")))
                    {
                        firstBlock.ClickBtnDelete();
                        flag = true;
                    }
                }
                Assert.True(flag);
            });
        }

        [Fact]
        public void RestoreCourse_ShouldRestoreCourse()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("RestoreCourse_ShouldRestoreCourse");
                string courseName = "CLR example";
                bool flag = false;
                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var tmp = courseView.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (firstBlock != null && (firstBlock.GetBtnDeleteText().Equals("Recover") || firstBlock.GetBtnDeleteText().Equals("Відновити")))
                    {
                        firstBlock.ClickBtnDelete();
                        flag = true;
                    }
                }
                Assert.True(flag);
            });
        }



        [Fact]
        public void ChangeCourse_ShouldChangeCourseData()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("ChangeCourse_ShouldChangeCourseData");
                string courseName = "ChangeMe", newCourseName = "WebDriver";
                
                bool flag = false;
                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var tmp = courseView.GetBlocks();
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (firstBlock != null)
                    {
                        firstBlock.ClickBtnChange();
                        var editPage = ConstructPage<CreateCoursePage>();
                        editPage.EditCourse(newCourseName, "New Description");
                        editPage.BtnOk.Click();
                        flag = true;
                    }
                }
                Assert.True(flag);
            });
        }



        [Fact]
        public void ChangeCourseOwner_ShouldChangeOwner()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("ChangeCourseOwner_ShouldChangeOwner");
                string courseName = "Owner";
                string owner = "";
                var header = ConstructPage<Header>().GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                var courseView = ConstructPage<ViewCoursesPage>();
                var tmp = courseView.GetBlocks();
                
                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (firstBlock != null)
                    {
                        firstBlock.ClickBtnChangeOwner();
                        var changeOwner = ConstructPage<ChangeCourseOwnerPage>();
                        owner = changeOwner.GetOwner();
                        changeOwner.ChangeOwner();
                    }
                }
                this.driver.RefreshPage();

                courseView = ConstructPage<ViewCoursesPage>();
                tmp = courseView.GetBlocks();

                if (tmp != null)
                {
                    var firstBlock = tmp.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (firstBlock != null)
                    {
                        firstBlock.ClickBtnChangeOwner();
                        var changeOwner = ConstructPage<ChangeCourseOwnerPage>();
                        var currenOwner = changeOwner.GetOwner();
                        Assert.NotEqual(owner,currenOwner);
                    }
                }
            });
        }
    }
}
