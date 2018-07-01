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
    public class CodeHistoryPage : BasePage
    {
        public CodeHistoryPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.ClassName, Using = "col-lg-3 tabs history active")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-2 tabs favourites")]
        public IWebElement FavouritesButton { get; set; }

        
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


      

    }
}
