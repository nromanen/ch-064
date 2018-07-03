using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

//MISHA

namespace OnlineExam.Pages.POM
{
    public class TaskViewPage : BasePage
    {
        public TaskViewPage() { }
        public TaskViewPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "form-control")]
        public IWebElement TaskName { get; set; }

        [FindsBy(How = How.ClassName, Using = "mce-content-body")]
        public IWebElement TaskDiscription { get; set; }

        [FindsBy(How = How.ClassName, Using = "CodeMirror-code")]
        public IWebElement TaskCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.col-md-1 > input")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div.col-md-2 > form > button")]
        public IWebElement StartButton { get; set; }

        [FindsBy(How = How.Id, Using = "tggl")]
        public IWebElement ShowHideCommentsButton { get; set; }

        [FindsBy(How = How.Id, Using = "buttn")]
        public IWebElement CommentButton { get; set; }

        public void ClickOnOkButton()
        {
            OkButton.Click();
        }

        public void ClickOnStartButton()
        {
            StartButton.Click();
        }

        public void ClickOnShowHideCommentsButton()
        {
            ShowHideCommentsButton.Click();
        }

    }
}