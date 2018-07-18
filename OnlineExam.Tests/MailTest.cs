using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using Xunit;


namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class MailTest : BaseTest
    {
        private Header header;
        private SideBar sideBar;

        public MailTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        string testMessage = $"{Guid.NewGuid()} Hola from Natasha";

        //[Fact]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            UITest(() =>
            {
                var contactUs = sideBar.GoToContactUsPage();
                contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var inbox = mailBox.InboxElementClick();
                var blocks = inbox.GetInboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
            });
        }

        //[Fact]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            UITest(() =>
            {
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                var outbox = mailBox.OutboxElementClick();
                var blocks = outbox.GetOutboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
            });
        }

        //[Fact]
        public void CheckIfUserCanSendEmail()
        {
            UITest(() =>
            {
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                Assert.True(result.UrlEndsWith("/EmailMessages"));
            });
        }

    }
}
