using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class CheckAnyInFavouritesN : BaseNTest
    {

        private Header header;
        private LogInPage logInPage;
        private SideBar sideBar;


        [SetUp]

        public override void SetUp()
        {
            base.SetUp();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void CheckAnyInFavourites()
        {
            LogProgress("Opening History page");
            var historyPage = sideBar.GoToCodeHistoryPage();
            var blocks = historyPage.GetHistoryBlocks();
            string id = "";
            LogProgress("Switching code to favourites");
            if (blocks.Any())
            {
                var firstBlock = blocks[0];
                id = firstBlock.GetId();
                firstBlock.IsLiked();
                historyPage.SwitchToFavourites();
            }
            LogProgress("Opening Favourites page");
            var favouritesPage = ConstructPage<HistoryFavouritePage>();
            LogProgress("Finding liked code");
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
