using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM.Tasks
{
    public class TasksPageRowItem : BasePageElement
    {
        /// <summary>
        /// Expected Table row
        /// </summary>
        /// <param name="webElement"></param>
        public TasksPageRowItem(IWebElement searchContext) : base(searchContext)
        {
        }

        /////////////////////////////////////TASKS PAGE//////////////////////////////////////////


        [FindsBy(How=How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement Name { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement Button { get; set; }
        [FindsBy(How =How.CssSelector, Using =":nth-child(3)")]
        public IWebElement Stars { get; set; }


        public string GetName()
        {
            return Name.Text;
        }

        public string GetButtonText()
        {
            return Button.Text;
        }

        public void ClickOnTasksButton()
        {
            Button.Click();
        }


        /////////////////////////////////////TEACHER EXERCISE MANAGER PAGE//////////////////////////////////////////

        [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement TaskName { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement CreationDate { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(3)")]
        public IWebElement UpdateDate { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(4)")]
        public IWebElement CourseName { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(5)")]
        public IWebElement AllButtons { get; set; }
      

        public string TEMP_GetName()
        {
            return TaskName.Text;
        }

        public string TEMP_GetCreationDate()
        {
            return CreationDate.Text;
        }

        public string TEMP_GetUpdateDate()
        {
            return UpdateDate.Text;
        }

        public string TEMP_GetCourseName()
        {
            return CourseName.Text;
        }

                




    }
}
