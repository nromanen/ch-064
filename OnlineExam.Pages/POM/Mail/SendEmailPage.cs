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
        private IWebElement BackToMailboxReference;

        [FindsBy(How = How.CssSelector, Using = "#name")]
        private IWebElement SubjectInput;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement EmailInput;

        [FindsBy(How = How.CssSelector, Using = "#message")]
        private IWebElement MessageInput;

        [FindsBy(How = How.CssSelector, Using = "#reused_form > input.btn.btn-primary.btn-send-email")]
        private IWebElement SubmitInput;

        /// <summary>
        /// Sends Email from Admin or Teacher to any user.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns>MailBoxPage</returns>
        public MailBoxPage SendEmail(string subject, string email, string message)
        {
            SubjectInput.SendKeys(subject);
            EmailInput.SendKeys(email);
            MessageInput.SendKeys(message);
            SubmitInput.Click();
            return ConstructPage<MailBoxPage>();
        }

        /// <summary>
        /// Returns user to Mailbox
        /// </summary>
        public void GoBackToMailbox()
        {
            BackToMailboxReference.Click();
        }
    }
}
