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
    [Collection("MyTestCollection")]
    public class MailTest : BaseTest
    {
        public MailTest()
        {
        }

        string testMessage = $"{Guid.NewGuid()} Hola from Natasha";

        [Fact]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            UITest(() =>
            {
                BeginTest();
                var sideBar = ConstructPage<SideBar>();
                var contactUs = sideBar.GoToContactUsPage();
                contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var inbox = mailBox.InboxElementClick();
                var blocks = inbox.GetInboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
            });
        }

        [Fact]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            UITest(() =>
            {
                BeginTest();
                var sideBar = ConstructPage<SideBar>();
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                Thread.Sleep(3000);
                var outbox = mailBox.OutboxElementClick();
                var blocks = outbox.GetOutboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
            });
        }

        [Fact]
        public void CheckIfUserCanSendEmail()
        {
            UITest(() =>
            {
                BeginTest();
                var sideBar = ConstructPage<SideBar>();
                var header = ConstructPage<Header>();
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                Thread.Sleep(3000);
                Assert.True(result.UrlEndsWith("/EmailMessages"));
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
