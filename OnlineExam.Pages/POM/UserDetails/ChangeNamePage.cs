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
        public ChangeNamePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "NewUserName")]
        public IWebElement NewUserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Save]")]
        public IWebElement SaveButton { get; set; }

        public void SetNewName( string newName, string password)
        {
            NewUserNameField.SendKeys(newName);
            PasswordField.SendKeys(password);
        }

        public void SaveNewName()
        {
            SaveButton.Click();
            return NewsPage(this.driver);
        }
    }
}
