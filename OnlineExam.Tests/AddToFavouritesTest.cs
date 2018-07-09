using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    public class AddToFavouritesTest : BaseTest
    {
        
        [Fact]
        public void TestAddToFovourites()
        {
            
            BeginTest();
            NavigateTo("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = ConstructPage<LogInPage>();
            var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);

            //var goToHistoryPage = new SideBar(driver).CodeHistoryMenuItemClick();
            //var goToHistoryPage = ConstructPage<SideBar>().CodeHistoryMenuItemClick();
            var historyPage = ConstructPage<HistoryFavouritePage>();
            var blocks = historyPage.GetHistoryBlocks();
            string id = "";
            if (blocks.Any())
            {
                var firstBlock = blocks[0];
                id = firstBlock.GetId();
                firstBlock.IsLiked();
                historyPage.SwitchToFavourites();
            }
            var favouritesPage = ConstructPage<HistoryFavouritePage>();
            var favouritesBlocks = favouritesPage.GetFavouriteBlocks();
            bool likedBlockFound = false;

            if (favouritesBlocks.Any())
            {
                foreach (var block in favouritesBlocks)
                {
                    if (block.GetId() == id)
                    {
                        likedBlockFound = true;
                        break;
                    }
                }
                
                Assert.True(likedBlockFound);
            }
        }
    }
}
