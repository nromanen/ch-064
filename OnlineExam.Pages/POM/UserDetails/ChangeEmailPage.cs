using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.UserDetails
{
    public class ChangeEmailPage : BasePage
    {

        [FindsBy(How = How.Id, Using = "NewEmail")]
        public IWebElement NewEmailField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Save]")]
        public IWebElement SaveButton { get; set; }

        /// <summary>
        /// Sets New Email to Email field, sets Confirm Password and clicks Save button.
        /// </summary>
        /// <param name="newEmail"></param>
        /// <param name="password"></param>
        public void SetNewEmail(string newEmail, string password)
        {
            NewEmailField.SendKeys(newEmail);
            PasswordField.SendKeys(password);
            SaveButton.Click();
        }

    }
}
