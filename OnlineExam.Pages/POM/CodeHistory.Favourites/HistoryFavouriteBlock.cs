using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.CodeHistory.Favourites
{
    public class HistoryFavouriteBlock : BasePageElement
    {
        public HistoryFavouriteBlock()
        {
        }

        [FindsBy(How = How.CssSelector, Using = ".titlecode")]
        public IWebElement Title { get; set; }

        public string GetTitle()
        {
            return Title.Text;
        }

        public void ClickOnTitle()
        {
            Title.Click();
        }

        public bool IsLiked()
        {
            return !LikeButton.GetCssValue("color").Equals("rgba(51,51,51,1)");
        }

        //[FindsBy(How = How.Id, Using = "code-example")]
        //public IWebElement IndexersFieldText { get; set; }

        //[FindsBy(How = How.Id, Using = "myBtn")]
        //public IWebElement SaveButton{ get; set; }

        //[FindsBy(How = How.ClassName, Using = "form-control col")]
        //public IWebElement TaskField { get; set; }

        //[FindsBy(How = How.ClassName, Using = "col-lg-12")]
        //public IWebElement TaskTime { get; set; }

        [FindsBy(How = How.Id, Using = "icon")]
        public IWebElement LikeButton { get; set; }

        //[FindsBy(How = How.ClassName, Using = "col-lg-1")]
        //public IWebElement StartButton { get; set; }

        //public void ReviewExecutedCode ()
        //{
        //    IndexersField.Click();
        //}

        //public CodeHistoryPage EditCodeText (string editCode)
        //{
        //    IndexersField.Click();
        //    IndexersFieldText.SendKeys(editCode);
        //    SaveButton.Click();
        //    return new CodeHistoryPage(this.driver);
        //}

        //public TasksPage OpenEditTaskPage()
        //{
        //    StartButton.Click();
        //    return new TasksPage(this.driver);
        //}



        ////Must be review
        //public void SaveToFavourites()
        //{
        //    string colorOfLikeButton = LikeButton.GetCssValue("style");
        //    if (colorOfLikeButton == "color:black;")
        //    {
        //        LikeButton.Click();
        //    }

        //}

        //public void DeleteFromFovourites()
        //{
        //    string colorOfLikeButton = LikeButton.GetCssValue("style");
        //    if (colorOfLikeButton == "color:red;")
        //    {
        //        LikeButton.Click();
        //    }
        //}
    }
}
