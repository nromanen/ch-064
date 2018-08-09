using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class LogInPage : BasePage
    {
        public LogInPage()
        {
        }

        [FindsBy(How = How.Id, Using = "emailLogin")]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "passwordLogin")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "RememberMe")]
        private IWebElement rememberMeCheckBox;

        [FindsBy(How = How.Id, Using = "submitLogin")]
        private IWebElement signInInputSubmit;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.validation-summary-errors > ul > li")]
        private IWebElement alert;

        public bool IsAlertVisible()
        {
            return alert.Displayed;
        }

        /// <summary>
        /// Signs in as given email and password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IndexPage SignIn(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            rememberMeCheckBox.Click();
            signInInputSubmit.Click();
            return ConstructPage<IndexPage>();
        }

        /// <summary>
        /// Checks if "Sign In" label is presented in Header.
        /// </summary>
        /// <returns></returns>
        public bool IsSignInPresentedInHeader()
        {
            Header header = ConstructPage<Header>();
            return header.GetSignInElement();
        }
    }
}