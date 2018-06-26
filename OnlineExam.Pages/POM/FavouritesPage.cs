using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class FavouritesPage : BasePage
    {
        public FavouritesPage(IWebDriver driver) : base(driver)
        {
        }
        [FindsBy(How = How.ClassName, Using = "col-lg-3 tabs history active")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-2 tabs favourites")]
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
