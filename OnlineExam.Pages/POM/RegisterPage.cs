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
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.Id, Using = "PasswordConfirm")]
        public IWebElement PasswordConfirmInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div:nth-child(4) > button")]
        public IWebElement RegistrationButton { get; set; }

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
