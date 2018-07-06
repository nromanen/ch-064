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
        public IWebElement NameInput { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement MessageTextArea { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reused_form > input.btn.btn-primary.btn-send-email")]
        public IWebElement SendSubmit { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(1) > div.col-lg-5 > a > img")]
        public IWebElement MapWithLink { get; set; }

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