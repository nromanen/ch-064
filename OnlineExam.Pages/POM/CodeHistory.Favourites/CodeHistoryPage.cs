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

        public CodeHistoryPage()
        {
            
        }

        [FindsBy(How=How.CssSelector, Using = ".historyblock > .row")]
        public IList<IWebElement> BlocksList { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-3 tabs history active")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "favourites")]
        public IWebElement FavouritesButton { get; set; }

        public IList<HistoryFavouriteBlock> GetBlocks()
        {
            var blocks = new List<HistoryFavouriteBlock>();
            foreach (var row in BlocksList)
            {
                var block = ConstructPageElement<HistoryFavouriteBlock>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        
        public FavouritesPage SwitchToFavourites()
        {
            FavouritesButton.Click();
            //return new FavouritesPage(this.driver);
            throw new Exception("Rewrite using Page constructor");
        }

        public CodeHistoryPage SwitchToHistory()
        {
            HistoryButton.Click();
            return this;
        } 


      

    }
}
