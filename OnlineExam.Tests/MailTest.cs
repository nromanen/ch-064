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
            //var contactUs = sideBar.ContactUsMenuItemElementClick();
            //contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Anna", "Hello admin!");
            //DateTime now = DateTime.Now;
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            var inbox = mailBox.InboxElementClick();
            //int hour;
            //if (now.Hour > 12)
            //{
            //    hour = now.Hour - 12;
            //}
            //else
            //{
            //    hour = now.Hour;
            //}
            //string expectedResult = Constants.EXAMPLE_EMAIL + " " + now.Month + "/" +
            //    now.Day + "/" + now.Year + " " + hour.ToString() + ":" + now.Minute + ":" + 
            //    now.Second + " PM";
            //Assert.True(mailBox.IsMailPresentedInInbox(expectedResult));
            Assert.StartsWith( Constants.EXAMPLE_EMAIL, inbox.GetInboxMail());
            //Assert.Contains(Constants.EXAMPLE_EMAIL, mailBox.GetInboxMail());
        }

        [Fact]
        public void CheckIfOutboxMessageIsVisible()
        {
            var sideBar = ConstructPage<SideBar>();
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            var sendEmail = mailBox.SendMessageReferenceClick();
            sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, "Hello");
            var outbox = mailBox.OutboxElementClick();
            Assert.True(outbox.IsMailPresentedInOutbox("Filipchukruslan@rambler.ru 5 / 28 / 2018 6:07:37 PM"));
            //Assert.;
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
