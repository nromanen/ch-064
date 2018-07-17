using NUnit.Framework;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OnlineExam.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    public class CheckAnyInFavouritesN : BaseTest
    {

        private Header header;
        private LogInPage logInPage;
        private SideBar sideBar;


        [SetUp]

        public void SetUp()
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckAnyInFavourites()
        {
            var historyPage = sideBar.GoToCodeHistoryPage();
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


        }
    }
    }

