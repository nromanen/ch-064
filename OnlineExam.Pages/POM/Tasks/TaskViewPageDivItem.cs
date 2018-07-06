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

        [FindsBy(How=How.CssSelector, Using = ".panel-body")]
        public IWebElement CommentText { get; set; }

        [FindsBy(How =How.CssSelector, Using = ".panel-footer")]
        public IWebElement CommentDate { get; set; }

        public string GetCommentDate()
        {
            return CommentDate.Text;
        }

        public string GetCommentText()
        {
            return CommentText.Text;
        }

        public string GetEmail()
        {
            return Email.Text;
        }

    }
}
