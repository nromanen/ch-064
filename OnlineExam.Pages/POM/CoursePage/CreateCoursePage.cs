using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class CreateCoursePage : BasePage
    {
        /// <summary>
        /// http://localhost:55842/CourseManagement/Create
        /// </summary>

        public CreateCoursePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement CourseNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        public IWebElement CourseDescriptionInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement CourseOkBtn { get; set; }
    }
}
