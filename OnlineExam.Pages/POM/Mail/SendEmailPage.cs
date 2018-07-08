using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class SendEmailPage : BasePage
    {

        public SendEmailPage()
        {

        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-3 > a")]
        public IWebElement BackToMailboxReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#name")]
        public IWebElement SubjectInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#email")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#message")]
        public IWebElement MessageInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reused_form > input.btn.btn-primary.btn-send-email")]
        public IWebElement SubmitInput { get; set; }

        public MailBoxPage SendEmail(string subject, string email, string message)
        {
            SubjectInput.SendKeys(subject);
            EmailInput.SendKeys(email);
            MessageInput.SendKeys(message);
            SubmitInput.Click();
            return ConstructPage<MailBoxPage>();
        }

        public void GoBackToMailbox()
        {
            BackToMailboxReference.Click();
        }
    }
}
