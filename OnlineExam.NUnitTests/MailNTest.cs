using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Basic")]
    public class MailNTest : BaseNTest
    {
        private Header header;
        private SideBar sideBar;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
           LogProgress("Done base set up");
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        string testMessage = $"{Guid.NewGuid()} Hola from Natasha";

        [Test]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            var contactUs = sideBar.GoToContactUsPage();
           LogProgress("Went to contact us page.");
            contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
           LogProgress("Written contact us message.");
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
           LogProgress($"Signed in as {Constants.ADMIN_EMAIL}.");
            var mailBox = sideBar.GoToMailBoxPage();
           LogProgress("Went to mail box page.");
            var inbox = mailBox.InboxElementClick();
           LogProgress("Inbox opened.");
            var blocks = inbox.GetInboxBlocksList();
           LogProgress("Got list of inbox blocks.");
            var doesMessageExist = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(doesMessageExist, "Message doesn't exist in inbox.");
        }

        [Test]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
           LogProgress($"Signed in as {Constants.ADMIN_EMAIL}.");
            var mailBox = sideBar.GoToMailBoxPage();
           LogProgress("Went to mail box page.");
            var sendEmail = mailBox.SendMessageReferenceClick();
           LogProgress("Opened send message page.");
            var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
           LogProgress("Email is sent.");
            var outbox = mailBox.OutboxElementClick();
           LogProgress("Outbox opened.");
            var blocks = outbox.GetOutboxBlocksList();
           LogProgress("Got list of outbox blocks.");
            var doesMessageExist = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(doesMessageExist, "Message doesn't exist in outbox.");
        }

        [Test]
        public void CheckIfUserCanSendEmail()
        {
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
           LogProgress($"Signed in as {Constants.ADMIN_EMAIL}.");
            var mailBox = sideBar.GoToMailBoxPage();
           LogProgress("Mailbox page opened.");
            var sendMessagePage = mailBox.SendMessageReferenceClick();
           LogProgress("Opened send message page.");
            var sendEmail = sendMessagePage.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
           LogProgress("Email is sent.");
            var result = sendEmail.UrlEndsWith("/EmailMessages");
            Assert.True(result, "EmailMessages page didn't return. User can't send email.");
        }
    }
}