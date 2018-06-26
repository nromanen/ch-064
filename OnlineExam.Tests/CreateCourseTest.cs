using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OnlineExam.Pages.POM;
using System.Threading;

namespace OnlineExam.Tests
{
    public class CreateCourseTest : BaseTest,IDisposable
    {
        public CreateCourseTest() { }

        [Fact]
        public void CreateCourse_ShouldCreateCourse()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn("teacher@gmail.com", "Teacher_123");
            var CourseMenu = new SideBar(driver).CoursesMenuItemClick();
            var CourseMenegmentPage = new CourseManagementPage(driver);
            CourseMenegmentPage.AddCourseBtn.Click();
            var CreateCoursePage = new CreateCoursePage(driver);
            CreateCoursePage.CourseNameInput.SendKeys("Unit test");
            Assert.Equal("Unit test", CreateCoursePage.CourseNameInput.GetAttribute("value").ToString());
            //Thread.Sleep(5000);
            CreateCoursePage.CourseDescriptionInput.SendKeys("tmp");
            Assert.Equal("tmp", CreateCoursePage.CourseDescriptionInput.GetAttribute("value").ToString());
            CreateCoursePage.CourseOkBtn.Click();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
