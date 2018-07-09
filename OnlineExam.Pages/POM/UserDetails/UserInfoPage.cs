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
        public UserInfoPage()  
        {
        }

      
        [FindsBy(How = How.Id, Using = "ChPaswBut1")]
        public IWebElement ChangePassButton { get; set; }

        [FindsBy(How = How.Id, Using = "ChPaswBut2")]
        public IWebElement ChangeNameButton { get; set; }

        [FindsBy(How = How.Id, Using = "ChPaswBut3")]
        public IWebElement ChangeEmailButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "col-lg-4")]
        public IList<IWebElement> Labels { get; set; }

        public string GetEmail()
        {
            return Labels[1].Text;
        }
        
        public ChangePasswordPage OpenChangePasswordPage()
        {
            ChangePassButton.Click();
            return ConstructPage<ChangePasswordPage>();
        }

        public ChangeNamePage OpenChangeNamePage()
        {
            ChangeNameButton.Click();
            return ConstructPage<ChangeNamePage>();
        }

        public ChangeEmailPage OpenChangeEmailPage()
        {
            ChangeEmailButton.Click();
            return ConstructPage<ChangeEmailPage>();
        }

        public bool HasChangeNameButton()
        {
            return ChangeNameButton != null;
        }

        public bool HasChangePasswordButton()
        {
            return ChangePassButton != null;
        }

        public bool HasChangeEmailButton()
        {
            return ChangeEmailButton != null;
        }
    }
}
