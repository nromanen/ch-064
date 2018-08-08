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
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        string testMessage = $"{Guid.NewGuid()} Hola from Natasha";

        [Test]
        public void CheckIfContactUsMessageIsVisibleInInbox()
        {
            var contactUs = sideBar.GoToContactUsPage();
            contactUs.ContactUs(Constants.EXAMPLE_EMAIL, "Name", testMessage);
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.GoToMailBoxPage();
            var inbox = mailBox.InboxElementClick();
            var blocks = inbox.GetInboxBlocksList();
            var doesMessageExist = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(doesMessageExist, "Message doesn't exist in inbox.");
        }

        [Test]
        public void CheckIfSendEmailIsVisibleInOutBox()
        {
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.GoToMailBoxPage();
            var sendEmail = mailBox.SendMessageReferenceClick();
            var result = sendEmail.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
            var outbox = mailBox.OutboxElementClick();
            var blocks = outbox.GetOutboxBlocksList();
            var doesMessageExist = blocks.Any(x => x.IsEqualText(testMessage));
            Assert.True(doesMessageExist, "Message doesn't exist in outbox.");
        }

        [Test]
        public void CheckIfUserCanSendEmail()
        {
            header.GoToLogInPage().SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
            var mailBox = sideBar.GoToMailBoxPage();
            var sendMessagePage = mailBox.SendMessageReferenceClick();
            var sendEmail = sendMessagePage.SendEmail("Subject", Constants.STUDENT_EMAIL, testMessage);
            var result = sendEmail.UrlEndsWith("/EmailMessages");
            Assert.True(result, "EmailMessages page didn't return. User can't send email.");
        }
    }
}