using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM.CodeHistory.Favourites
{
    public class HistoryFavouritePage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = ".historyblock > .row")]
        public IList<IWebElement> BlocksListHistory { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-3 tabs history active")]
        public IWebElement HistoryButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "favourites")]
        public IWebElement FavouritesButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".favouritesblock > .row")]
        public IList<IWebElement> BlocksListFavourites { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".checkbox_wrapper label")]
        public IWebElement LikeButton { get; set; }

        public bool IsHistory
        {
            get
            {
                return HistoryButton.GetAttribute("class").Contains("active");
            }
        }

        public IList<HistoryFavouriteBlock> GetHistoryBlocks()
        {
            var blocks = new List<HistoryFavouriteBlock>();
            foreach (var row in BlocksListHistory)
            {
                var block = ConstructPageElement<HistoryFavouriteBlock>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        public IList<HistoryFavouriteBlock> GetFavouriteBlocks()
        {
            var blocks = new List<HistoryFavouriteBlock>();
            foreach (var row in BlocksListFavourites)
            {
                var block = ConstructPageElement<HistoryFavouriteBlock>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }


        public HistoryFavouritePage SwitchToFavourites()
        {
            FavouritesButton.Click();
            return this;
        }

        public HistoryFavouritePage SwitchToHistory()
        {
            HistoryButton.Click();
            return this;
        }

        public string GetId()
        {
            return LikeButton.GetAttribute("data-id");
        }

       


    }
    
}
