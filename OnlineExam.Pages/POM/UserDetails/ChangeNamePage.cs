using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.UserDetails
{
    public class ChangeNamePage : BasePage
    {
        public ChangeNamePage()
        {
        }

        [FindsBy(How = How.Id, Using = "NewUserName")]
        public IWebElement NewUserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Save]")]
        public IWebElement SaveButton { get; set; }

        /// <summary>
        /// Sets New Name to Name field, sets Confirm Password and clicks Save button.
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="password"></param>
        public void SetNewName( string newName, string password)
        {
            NewUserNameField.SendKeys(newName);
            PasswordField.SendKeys(password);
            SaveButton.Click();
        }

    }
}
