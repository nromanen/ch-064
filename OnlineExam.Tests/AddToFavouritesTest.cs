using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
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
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);

            var goToHistoryPage = new SideBar(driver).CodeHistoryMenuItemClick();
            var likeCode = new HistoryBlock(driver);
            likeCode.SaveToFavourites();

            Assert.

        }
    }
}
