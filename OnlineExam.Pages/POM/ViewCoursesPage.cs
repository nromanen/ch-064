using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class ViewCoursesPage : BasePage
    {
        /// <summary>
        /// http://localhost:55842/CourseManagement/ViewCourses
        /// </summary>

        public ViewCoursesPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.LinkText, Using = "Add course")]
        public IWebElement AddCourseBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Change")]
        public IWebElement ChangeBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Delete")]
        public IWebElement DeleteBtn { get; set; }
    }
}
