using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class RegisterPage : BasePage
    {
        public RegisterPage()
        {
        }

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement EmailInput;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement PasswordInput;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"PasswordConfirm\"]")]
        private IWebElement PasswordConfirmInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[4]/button")]
        private IWebElement RegistrationButton;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.validation-summary-errors > ul > li")]
        private IWebElement alert;

        public bool IsAlertVisible()
        {
            return alert.Displayed;
        }

        /// <summary>
        /// Does registration using given email, password and password confirm.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirm"></param>
        /// <returns></returns>
        public IndexPage Registration(string email, string password, string passwordConfirm)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            PasswordConfirmInput.SendKeys(passwordConfirm);
            WaitWhileNotClickableWebElement(RegistrationButton);
            RegistrationButton.Click();
            return ConstructPage<IndexPage>();
        }
    }
}
