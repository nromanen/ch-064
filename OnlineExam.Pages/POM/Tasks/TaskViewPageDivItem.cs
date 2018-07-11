using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineExam.Pages.POM.Tasks
{
    public class TaskViewPageDivItem : BasePageElement
    {

        public TaskViewPageDivItem()
        {        }

        [FindsBy(How = How.CssSelector, Using = ".panel-heading")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".panel-body")]
        public IWebElement CommentText { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".panel-footer")]
        public IWebElement CommentDate { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".panel-heading > span")]
        public IWebElement Starss { get; set; }
        /// <summary>
        /// return count of stars (rating)
        /// </summary>
        /// <returns></returns>
        public string GetStarsss()
        {
            var count = Starss.GetAttribute("data-default-rating");
            return count.ToString();
        }
        /// <summary>
        /// return comment date of comment
        /// </summary>
        /// <returns></returns>
        public string GetCommentDate()
        {
            return CommentDate.Text;
        }
        /// <summary>
        /// return comment text of comment
        /// </summary>
        /// <returns></returns>
        public string GetCommentText()
        {
            return CommentText.Text;
        }
        /// <summary>
        /// return email of comment
        /// </summary>
        /// <returns></returns>
        public string GetEmail()
        {
            return Email.Text;
        }

    }
}
