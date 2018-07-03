using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class FavouritesPage : BasePage 
        
    {
        public FavouritesPage(IWebDriver driver) : base(driver)
        {
        }
        [FindsBy(How = How.ClassName, Using = "history")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "favourites")]
        public IWebElement FavouritesButton { get; set; }

        

        public CodeHistoryPage SwitchToHistory()
        {
            HistoryButton.Click();
            return new CodeHistoryPage(this.driver);
        }

        public FavouritesPage SwitchToFavourites()
        {
            FavouritesButton.Click();
            return this;
        }

        
    }
}
