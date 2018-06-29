using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.UserDetails
{
    public class UserInfoPage : BasePage
    {
        public UserInfoPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "ChPaswBut1")]
        public IWebElement ChangePassButton { get; set; }

        [FindsBy(How = How.Id, Using = "ChPaswBut2")]
        public IWebElement ChangeNameButton { get; set; }

        [FindsBy(How = How.Id, Using = "ChPaswBut3")]
        public IWebElement ChangeEmailButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-4")]
        public IWebElement Email { get; set; }
        
        public ChangePasswordPage OpenChangePasswordPage()
        {
            ChangePassButton.Click();
            return new ChangePasswordPage(this.driver);
        }

        public ChangeNamePage OpenChangeNamePage()
        {
            ChangeNameButton.Click();
            return new ChangeNamePage(this.driver);
        }

        public ChangeEmailPage OpenChangeEmailPage()
        {
            ChangeEmailButton.Click();
            return new ChangeEmailPage(this.driver);
        }

    }
}
