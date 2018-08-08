using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class ContactUsPage : BasePage
    {
        public ContactUsPage()
        {
        }

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement NameInput;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement EmailInput;

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement MessageTextArea;

        [FindsBy(How = How.CssSelector, Using = "#reused_form > input.btn.btn-primary.btn-send-email")]
        private IWebElement SendSubmit;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(1) > div.col-lg-5 > a > img")]
        private IWebElement MapWithLink;

        /// <summary>
        /// Send Contact us message to exact email and name with exact text
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public ContactUsPage ContactUs(string email, string name, string text)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            MessageTextArea.SendKeys(text);
            SendSubmit.Click();
            return ConstructPage<ContactUsPage>();
        }
    }
}