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
        public void ContactUsTest()
        {
            var sideBar = ConstructPage<SideBar>();
            var contactUs = sideBar.GoToContactUsPage();
            contactUs.ContactUs();
            var header = ConstructPage<Header>();
            header.SignOut();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.GoToMailBoxPage();
            Thread.Sleep(500);
            mailBox.IsMailPresentedInMailList("ewrtyuio");
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
