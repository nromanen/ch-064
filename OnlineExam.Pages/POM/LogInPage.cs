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

        public LogInPage(IWebDriver driver) : base(driver)
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
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Login");
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            signInInputSubmit.Click();
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            return new IndexPage(driver);
        }
    }
}
