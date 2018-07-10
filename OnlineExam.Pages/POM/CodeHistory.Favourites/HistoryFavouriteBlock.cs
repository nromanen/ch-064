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

        [FindsBy(How = How.CssSelector, Using = "save-changes-btn")]
        public IWebElement SaveButton { get; set; }


        [FindsBy(How = How.CssSelector, Using = ".form-control.col")]
        public IWebElement TextArea { get; set; }

        public string GetTextArea()
        {
            return TextArea.Text;
        }

        
        [FindsBy(How = How.CssSelector, Using = ".date p")]
        public IWebElement Date { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".checkbox_wrapper label")]
        public IWebElement LikeButton { get; set; }

        public bool IsLiked()
        {
            return LikeButton.GetCssValue("color").Equals("rgba(255,0,0,1)");
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-default")]
        public IWebElement StartButton { get; set; }

        public string GetId()
        {
            return LikeButton.GetAttribute("data-id");
        }

        public void EditExecutedCode()
        {
            Title.Click();
        }

        public void SaveToFavourites()
        {
            string colorOfLikeButton = LikeButton.GetCssValue("style");
            if (colorOfLikeButton == "color:black;")
            {
                LikeButton.Click();
            }

        }

        public void DeleteFromFovourites()
        {
            string colorOfLikeButton = LikeButton.GetCssValue("style");
            if (colorOfLikeButton == "color:red;")
            {
                LikeButton.Click();
            }
        }
    }
}
