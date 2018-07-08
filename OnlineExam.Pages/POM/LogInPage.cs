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
        public IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "passwordLogin")]
        public IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "RememberMe")]
        public IWebElement rememberMeCheckBox;

        [FindsBy(How = How.Id, Using = "submitLogin")]
        public IWebElement signInInputSubmit;

      

        public IndexPage SignIn(string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            rememberMeCheckBox.Click();
            signInInputSubmit.Click();
            Thread.Sleep(1000);
            driver.Refresh();
            return ConstructPage<IndexPage>();
        }

        

        public bool IsSignInPresentedInHeader()
        {
            Header header = ConstructPage<Header>();

            return header.GetSignInElement();
        }
    }
}