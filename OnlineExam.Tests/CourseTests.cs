using System;
using Xunit;
using OnlineExam.Pages.POM;
using System.Threading;
using Xunit.Abstractions;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using OnlineExam.Framework;

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
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage().CreateCourse(courseName, courseDescription);
                var courseManagment = ConstructPage<CourseManagementPage>();

                var blockList = courseManagment.GetBlocks();
                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(courseName, singleBlock.GetCourseName());
                }
            });
        }

        [Fact]
        public void CreateCourse_InvalidData()
        {
            UITest(() =>
            {
                string courseName = String.Empty, courseDescription = "Description";
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage().CreateCourse(courseName,courseDescription);
                var courseManagment = ConstructPage<CourseManagementPage>();

                var blockList = courseManagment.GetBlocks();
                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    Assert.Null(singleBlock);
                }
            });
        }

        [Fact]
        public void DeleteCourse_ShouldDeleteCourse()
        {
            UITest(() =>
            {
                string courseName = "Selenium";
                bool flag = false;
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var blockList = courseView.GetBlocks();
                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));                
                    if (singleBlock != null && (singleBlock.GetBtnDeleteText().Equals("Delete") || singleBlock.GetBtnDeleteText().Equals("Видалити")))
                    {
                        singleBlock.ClickBtnDelete();
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
                string courseName = "CLR example";
                bool flag = false;
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                courseManagment.BtnMyCourses.Click();
                var courseView = ConstructPage<ViewCoursesPage>();
                var blockList = courseView.GetBlocks();
                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (singleBlock != null && (singleBlock.GetBtnDeleteText().Equals("Recover") || singleBlock.GetBtnDeleteText().Equals("Відновити")))
                    {
                        singleBlock.ClickBtnDelete();
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
                string courseName = "ChangeMe", newCourseName = "WebDriver";
                
                bool flag = false;
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
                var sidebar = ConstructPage<SideBar>().GoToCourseManagementPage();
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
                string courseName = "Owner";
                string owner = "";
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var sidebar = ConstructPage<SideBar>();
                sidebar.GoToCourseManagementPage();
                var courseManagment = ConstructPage<CourseManagementPage>();
                var courseView = ConstructPage<ViewCoursesPage>();
                var blockList = courseView.GetBlocks();
                
                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (singleBlock != null)
                    {
                        singleBlock.ClickBtnChangeOwner();
                        var changeOwner = ConstructPage<ChangeCourseOwnerPage>();
                        owner = changeOwner.GetOwner();
                        changeOwner.ChangeOwner();
                    }
                }
                this.driver.RefreshPage();

                courseView = ConstructPage<ViewCoursesPage>();
                blockList = courseView.GetBlocks();

                if (blockList != null)
                {
                    var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                    if (singleBlock != null)
                    {
                        singleBlock.ClickBtnChangeOwner();
                        var changeOwner = ConstructPage<ChangeCourseOwnerPage>();
                        var currenOwner = changeOwner.GetOwner();
                        Assert.NotEqual(owner,currenOwner);
                    }
                }
            });
        }
    }
}
