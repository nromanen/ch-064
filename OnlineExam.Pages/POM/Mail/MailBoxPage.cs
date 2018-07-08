using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using OnlineExam.Pages.POM.Mail;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class MailBoxPage : BasePage
    {

        public MailBoxPage()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(1) > a")]
        public IWebElement SendMessageReference { get; set; }

        [FindsBy(How = How.ClassName, Using = "Outbox")]
        public IWebElement OutboxElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "Inbox")]
        public IWebElement InboxElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#InBoxMEssages > p")]
        public IList<IWebElement> InboxMailList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#OutBoxMEssages > p")]
        public IList<IWebElement> OutboxMailList { get; set; }

        public MailBoxPage InboxElementClick()
        {
            WaitWhileNotClickableWebElement(InboxElement);
            InboxElement.Click();
            return ConstructPage<MailBoxPage>();
        }

        public MailBoxPage OutboxElementClick()
        {
            WaitWhileNotClickableWebElement(OutboxElement);
            OutboxElement.Click();
            return ConstructPage<MailBoxPage>();
        }

        public SendEmailPage SendMessageReferenceClick()
        {
            WaitWhileNotClickableWebElement(SendMessageReference);
            SendMessageReference.Click();
            return ConstructPage<SendEmailPage>();
        }

        public IList<InboxBlock> GetInboxBlocksList()
        {
            var inboxBlocksList = new List<InboxBlock>();
            for (var i = 0; i < InboxMailList.Count; i = i + 2)
            {
                var block = new InboxBlock();
                block.SetDriver(this.driver);
                block.Header = InboxMailList[i];
                block.Message = InboxMailList[i + 1];
                inboxBlocksList.Add(block);
            }
            return inboxBlocksList;
        }

        public bool IsMailPresentedInInbox(string header)
        {
            var inboxBlocksList = GetInboxBlocksList();
            foreach (var block in inboxBlocksList)
            {
                if (block.Header.Text.StartsWith(header))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMailPresentedInOutbox(string header)
        {
            var outboxBlocksList = GetOutboxBlocksList();
            foreach (var block in outboxBlocksList)
            {
                if (block.Header.Text.StartsWith(header))
                {
                    return true;
                }
            }
            return false;
        }

        public IList<OutboxBlock> GetOutboxBlocksList()
        {
            var outboxBlocksList = new List<OutboxBlock>();
            for (var i = 0; i < OutboxMailList.Count; i = i + 2)
            {
                var block = new OutboxBlock();
                block.SetDriver(this.driver);
                block.Header = OutboxMailList[i];
                block.Message = OutboxMailList[i + 1];
                outboxBlocksList.Add(block);
            }
            return outboxBlocksList;
        }
    }

}