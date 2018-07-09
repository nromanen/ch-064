using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OnlineExam.Pages.POM.UserDetails;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class AddToFavouriteTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        


        public AddToFavouriteTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            //logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            
        }

        [Fact]
        public void TestAddToFovourites()
        {
            UITest(() =>
            {
            fixture.test = fixture.extentReports.CreateTest("TestAddToFavourites");
            //BeginTest();
            //NavigateTo("http://localhost:55842/Account/Login");
            //System.Threading.Thread.Sleep(1000);
            //var loginPage = ConstructPage<LogInPage>();
            //var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);

            //var goToHistoryPage = new SideBar(driver).CodeHistoryMenuItemClick();
            //var goToHistoryPage = ConstructPage<SideBar>().CodeHistoryMenuItemClick();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
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
                }
                Assert.True(likedBlockFound);
                fixture.test.Log(Status.Pass, "Code ia added to favourites");
            });
            
        }
    }
}
