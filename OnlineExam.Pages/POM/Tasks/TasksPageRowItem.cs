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
      
        public TasksPageRowItem(IWebElement searchContext) : base(searchContext)
        {
        }

        public TasksPageRowItem()
        {
          
        }

        [FindsBy(How=How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement Name { get; set; }
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2) > a")]
        public IWebElement Button { get; set; }
        [FindsBy(How =How.CssSelector, Using =":nth-child(3) > span")]
        public IWebElement Stars { get; set; }
        /// <summary>
        /// return count of stars (rating)
        /// </summary>
        /// <returns></returns>
        public string GetStarsss()
        {
            var count = Stars.GetAttribute("data-default-rating");
            return count.ToString();
        }
        /// <summary>
        /// return task name
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return Name.Text;
        }
        /// <summary>
        /// "tasks" button will be clicked on
        /// </summary>
        public void ClickOnTasksButton()
        {
            Button.Click();
        }
        /// <summary>
        /// return property of stars
        /// </summary>
        public void StarsCount()
        {
            Stars.GetProperty("star active");
        }

    }
}
