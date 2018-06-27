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
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            rememberMeCheckBox.Click();
            signInInputSubmit.Click();
            Thread.Sleep(1000);

            driver.Navigate().Refresh();

            Thread.Sleep(1000);

            return new IndexPage(driver);
        }

        public bool IsUserEmailPresentedInHeader(string email)
        {
            Header header = new Header(driver);

            if (header.GetText("CssSelector", "#gn-menu > li:nth-child(3) > a:nth-child(1)") == email.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
