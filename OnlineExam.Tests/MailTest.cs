using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    public class MailTest : BaseTest, IDisposable
    {
        public MailTest()
        {
        }

        [Fact]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            var sideBar = ConstructPage<SideBar>();
            var contactUs = sideBar.ContactUsMenuItemElementClick();
            contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", "Text");
            DateTime now = DateTime.Now;
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            Thread.Sleep(500);
            string expectedResult = Constants.EXAMPLE_EMAIL + " " + now.Month + "/" +
                now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second + " PM";
            Assert.True(mailBox.IsMailPresentedInInbox(expectedResult));
        }

        [Fact]
        public void CheckIfOutboxMessageIsVisible()
        {

        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
