using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class TaskViewPage : BasePage
    {
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
        public IWebElement OkButtonInTaskView { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div.col-md-2 > form > button")]
        public IWebElement StartButtonInTaskView { get; set; }

        [FindsBy(How = How.Id, Using = "tggl")]
        public IWebElement ShowHideCommentsButtonInTaskView { get; set; }

        [FindsBy(How = How.Id, Using = "buttn")]
        public IWebElement CommentButtonInTaskView { get; set; }

        public void ClickOnOkButtonInTaskView()
        {
            OkButtonInTaskView.Click();
        }

        public void ClickOnStartButtonInTaskView()
        {
            StartButtonInTaskView.Click();
        }

        public void ClickOnShowHideCommentsButtonInTaskView()
        {
            ShowHideCommentsButtonInTaskView.Click();
        }

        public void CreateNewCommentInTaskView(string Comment, int CountOfStars)
        {
            driver.Navigate().GoToUrl("http://localhost:55842/ExerciseManagement/TaskView/1");
            IWebElement element = driver.FindElement(By.Id("textField"));
            element.SendKeys(Comment);
            // RATING && Url (1)
            CommentButtonInTaskView.Click();
        }



    }
}