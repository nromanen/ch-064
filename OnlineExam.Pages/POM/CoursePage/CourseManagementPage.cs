using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class CourseManagementPage : BasePage
    {
        /// <summary>
        /// Course managment as teacher
        /// http://localhost:55842/CourseManagement
        /// </summary>

        public CourseManagementPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = ".container > a:nth-child(1)")]
        public IWebElement AddCourseBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "My courses")]
        public IWebElement MyCoursesBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "bluehighl")]
        public IWebElement CourseNameLink { get; set; }

        public void CreateCourse()
        {
            AddCourseBtn.Click();
        }
    }
}
