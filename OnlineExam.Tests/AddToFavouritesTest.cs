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
        public AddToFavouritesTest()
        {
        }

        [Fact]
        public void TestAddToFovourites()
        {
            BeginTest();
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = new LogInPage(driver);
            var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);

            var goToHistoryPage = new SideBar(driver).CodeHistoryMenuItemClick();
            var historyPage = new CodeHistoryPage(driver);
            var blocks = historyPage.GetBlocks();
            string id = "";
            if (blocks.Any())
            {
                var firstBlock = blocks[0];
                id = firstBlock.GetId();
                firstBlock.IsLiked();
                historyPage.SwitchToFavourites();             
            } 
            var favouritesPage = new FavouritesPage(driver);
            var favouritesBlocks = favouritesPage.GetBlocks();
            bool likedBlockFound = false;

            if (favouritesBlocks.Any())
            {
                foreach(var block in favouritesBlocks)
                {
                    if(block.GetId() == id)
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
