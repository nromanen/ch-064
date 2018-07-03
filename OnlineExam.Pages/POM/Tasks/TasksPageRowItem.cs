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
    }
}
