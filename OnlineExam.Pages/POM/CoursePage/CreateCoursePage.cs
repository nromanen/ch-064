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
        // ../CourseManagement/Create
        public CreateCoursePage() { }

        [FindsBy(How = How.Id, Using = "Name")]
        public IWebElement CourseNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "Description")]
        public IWebElement CourseDescriptionInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='Ok']")]
        public IWebElement BtnOk { get; set; }

        /// <summary>
        /// Method returns course name (title) from input 'value' attribute
        /// </summary>
        public string GetCourseName()
        {
            return CourseNameInput.GetAttribute("value");
        }

        /// <summary>
        /// Method returns course description from input 'value' attribute
        /// </summary>
        public string GetCourseDescription()
        {
            return CourseDescriptionInput.GetAttribute("value");
        }

        /// <summary>
        /// Method clear all inputs and put passing params into inputs
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void EditCourse(string name, string description)
        {
            CourseNameInput.Clear();
            CourseDescriptionInput.Clear();
            CourseNameInput.SendKeys(name);
            CourseDescriptionInput.SendKeys(description);
        }

        /// <summary>
        /// Method put passing params into course name input and course description input
        /// </summary>
        public void FillCourse(string name, string description)
        {
            CourseNameInput.SendKeys(name);
            CourseDescriptionInput.SendKeys(description);
        }

        /// <summary>
        /// Method click 'Ok' button
        /// </summary>
        public void ClickBtnOk()
        {
            BtnOk.Click();
        }
    }
}
