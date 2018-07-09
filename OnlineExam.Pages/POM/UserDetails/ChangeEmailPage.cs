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

        public void SetNewEmail(string newEmail, string password)
        {
            NewEmailField.SendKeys(newEmail);
            PasswordField.SendKeys(password);
            SaveButton.Click();
        }

        //public NewsPage SaveNewEmail()
        //{
        //    SaveButton.Click();
        //    return ConstructPage<NewsPage>();
            //try
            //{

            //    //return new NewsPage(this.driver);
            //    throw new Exception("Rewrite using Page constructor");
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        //}
    }
}
