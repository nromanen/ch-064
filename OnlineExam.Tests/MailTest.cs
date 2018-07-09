using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
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

        [Fact]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CheckIfContactUsMessageIsVisibleInInbox");
                var contactUs = sideBar.GoToContactUsPage();
                contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var inbox = mailBox.InboxElementClick();
                var blocks = inbox.GetInboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
                fixture.test.Log(Status.Pass, "Contact Us Message Is Visible In Inbox.");
            });
        }

        [Fact]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CheckIfSendEmailIsVisibleInOutBox");
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                Thread.Sleep(3000);
                var outbox = mailBox.OutboxElementClick();
                var blocks = outbox.GetOutboxBlocksList();
                var existMessage = blocks.Any(x => x.IsEqualText(testMessage));
                Assert.True(existMessage);
                fixture.test.Log(Status.Pass, "Send Email Is Visible In OutBox.");
            });
        }

        [Fact]
        public void CheckIfUserCanSendEmail()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CheckIfUserCanSendEmail");
                header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var mailBox = sideBar.GoToMailBoxPage();
                var sendEmail = mailBox.SendMessageReferenceClick();
                var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
                Thread.Sleep(3000);
                Assert.True(result.UrlEndsWith("/EmailMessages"));
                fixture.test.Log(Status.Pass, "User Can Send Email.");
            });
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
