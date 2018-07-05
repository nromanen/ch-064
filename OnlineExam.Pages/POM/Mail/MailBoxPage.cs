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
        public MailBoxPage(IWebDriver driver) : base(driver)
        {
        }

        public MailBoxPage()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(1) > a")]
        public IWebElement SendMessageReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#InBoxMEssages > p")]
        public IList<IWebElement> InboxMailList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#OutBoxMEssages > p")]
        public IList<IWebElement> OutboxMailList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(2) > div")]
        public IWebElement OutboxElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(1) > div")]
        public IWebElement InboxElement { get; set; }

        public InboxBlock InboxElementClick()
        {
            InboxElement.Click();
            return new InboxBlock();
        }

        public OutboxBlock OutboxElementClick()
        {
            OutboxElement.Click();
            return new OutboxBlock();
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

        public string GetInboxMail()
        {
            string result="";
            var inboxBlocksList = GetInboxBlocksList();
            foreach(var block in inboxBlocksList)
            {
                result += block.Header.Text+" ";
            }
            return result;
        }

        public string GetOutboxMail()
        {
            string result = "";
            var outboxBlocksList = GetOutboxBlocksList();
            foreach (var block in outboxBlocksList)
            {
                result += block.Header.Text + " ";
            }
            return result;
        }

        public bool IsMailPresentedInInbox (string email)
        {
            var inboxBlocksList = GetInboxBlocksList();
            foreach (var block in inboxBlocksList)
            {
                if (block.Header.Text.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsMailPresentedInOutbox(string email)
        {
            var outboxBlocksList = GetOutboxBlocksList();
            foreach (var block in outboxBlocksList)
            {
                if (block.Header.Text.Equals(email))
                {
                    return true;
                }
            }
            return false;
        }
    }

}