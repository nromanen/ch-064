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
        public RegisterPage(IWebDriver driver) : base(driver)
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

        public IndexPage Registration(string email, string password, string passwordConfirm)
        {
            driver.Navigate().GoToUrl("http://localhost:55842/Account/Register");
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            PasswordConfirmInput.SendKeys(passwordConfirm);
            RegistrationButton.Click();
            return new IndexPage(driver);
        }
    }
}
