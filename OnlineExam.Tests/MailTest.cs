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

        string testMessage = $"{Guid.NewGuid()} Hola from Natasha";

        [Fact]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            var sideBar = ConstructPage<SideBar>();
            var contactUs = sideBar.ContactUsMenuItemElementClick();
            contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            var inbox = mailBox.InboxElementClick();
            var blocks = inbox.GetInboxBlocksList();
            var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(existMessage);
        }

        [Fact]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            var sideBar = ConstructPage<SideBar>();
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            var sendEmail = mailBox.SendMessageReferenceClick();
            var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
            Thread.Sleep(3000);
            var outbox = mailBox.OutboxElementClick();
            var blocks = outbox.GetOutboxBlocksList();
            var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(existMessage);
        }

        [Fact]
        public void CheckIfUserCanSendEmail()
        {
            var sideBar = ConstructPage<SideBar>();
            var header = ConstructPage<Header>();
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.MailBoxMenuItemElementClick();
            var sendEmail = mailBox.SendMessageReferenceClick();
            var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
            Thread.Sleep(3000);
            Assert.Equal("http://localhost:55842/EmailMessages", result.GetCurrentUrl());
        }

            public void Dispose()
        {
            driver.Dispose();
        }
    }
}
