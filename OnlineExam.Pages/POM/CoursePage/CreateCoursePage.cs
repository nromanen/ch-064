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

        public CreateCoursePage()
        {

        }
        /// <summary>
        /// http://localhost:55842/CourseManagement/Create
        /// </summary>

        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement CourseNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        public IWebElement CourseDescriptionInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement CourseOkBtn { get; set; }

        public void FillCourse(string name, string description)
        {
            CourseNameInput.SendKeys(name);
            CourseDescriptionInput.SendKeys(description);
        }

        public string GetName()
        {
            return CourseNameInput.GetAttribute("value");
        }

        public string GetDescription()
        {
            return CourseDescriptionInput.GetAttribute("value");
        }

        public void EditCourse(string name, string description)
        {
            CourseNameInput.Clear();
            CourseDescriptionInput.Clear();
            CourseNameInput.SendKeys(name);
            CourseDescriptionInput.SendKeys(description);
        }
    }
}
