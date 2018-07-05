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

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(2) > div")]
        public IWebElement OutboxElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(1) > div")]
        public IWebElement InboxElement { get; set; }

        public InboxBlock InboxElementClick()
        {
            WaitWhileNotClickableWebElement(InboxElement);
            InboxElement.Click();
            return new InboxBlock();
        }

        public OutboxBlock OutboxElementClick()
        {
            WaitWhileNotClickableWebElement(OutboxElement);
            OutboxElement.Click();
            return new OutboxBlock();
        }

        public SendEmailPage SendMessageReferenceClick()
        {
            WaitWhileNotClickableWebElement(SendMessageReference);
            SendMessageReference.Click();
            return ConstructPage<SendEmailPage>();
        }



        
    }

}