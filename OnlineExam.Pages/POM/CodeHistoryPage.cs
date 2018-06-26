using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class CodeHistoryPage : BasePage
    {
        public CodeHistoryPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "col-lg-3 tabs history active")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-2 tabs favourites")]
        public IWebElement FavouritesButton { get; set; }



        [FindsBy(How = How.ClassName, Using = "form-control titlecode")]
        public IWebElement IndexersField { get; set; }

        [FindsBy(How = How.ClassName, Using = "form-control col")]
        public IWebElement TaskField { get; set; }


        [FindsBy(How = How.ClassName, Using = "col-lg-12")]
        public IWebElement TaskTime { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkbox_wrapper col-lg-1")]
        public IWebElement LikeButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-1")]
        public IWebElement StartButton { get; set; }

        public FavouritesPage SwitchToFavourites()
        {
            FavouritesButton.Click();
            return new FavouritesPage(this.driver);
        }

        public CodeHistoryPage SwitchToHistory()
        {
            HistoryButton.Click();
            return this;
        }

        public void SaveToFavourites()
        {
            LikeButton.Click();
            
        }

        //public void OpenEditTaskPage()
        //{
        //    LikeButton.Click();
        //    return new TaskPage(this.driver);
        //}

    }
}
