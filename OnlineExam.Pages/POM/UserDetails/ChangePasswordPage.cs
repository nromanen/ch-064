using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.UserDetails
{
    public class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage()
        {
        }

        [FindsBy(How = How.Id, Using = "OldPassword")]
        public IWebElement OldPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "NewPassword")]
        public IWebElement NewPasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "ConfirmNewPassword")]
        public IWebElement ConfirmNewPasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value=Save]")]
        public IWebElement SaveButton { get; set; }

        /// <summary>
        /// Sets Old Password, New Password, Confirm Password and clicks Save button.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="confirmNewPassword"></param>
        public void SetNewPassword (string oldPassword, string newPassword, string confirmNewPassword)
        {
            OldPasswordField.SendKeys(oldPassword);
            NewPasswordField.SendKeys(newPassword);
            ConfirmNewPasswordField.SendKeys(confirmNewPassword);
            SaveButton.Click();
        }

    }
}
