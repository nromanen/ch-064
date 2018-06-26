using System;
using System.Collections.Generic;
using System.Linq;
using OnlineExam.Pages.POM.UserDetails;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
    public class Header : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "#gn-menu")]
        private IWebElement headerElement;

        [FindsBy(How = How.CssSelector, Using = "#requestCulture_RequestCulture_UICulture_Name")]
        private IWebElement changeLanguageSelectElement;

        [FindsBy(How = How.CssSelector, Using = "#gn-menu > li:nth-child(2) > a")]
        //@"a[href*='/']"      is available but can not to click on it
        private IWebElement homePageLinkElement;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement signOutButtonElement;

        [FindsBy(How = How.CssSelector, Using = @"[href*='/Account/Login']")]
        private IWebElement signInLinkElement;

        [FindsBy(How = How.CssSelector, Using = @"[href*='/Account/Register']")]
        private IWebElement signUpLinkElement;

        [FindsBy(How = How.CssSelector, Using = "#gn-menu > li:nth-child(3) > a:nth-child(1)")]
        //@"a[href*='/User']"    is available but can not to click on it
        private IWebElement userAccountManageLinkElement;
        //масив і працювати з масивом


        public Header(IWebDriver driver) : base(driver)
        {
        }


        public NewsPage GoToHomePage(string text)
        {

            IList<IWebElement> headerList = headerElement.FindElements(By.TagName("li"));
            foreach (var element in headerList)
            {
                
                Console.WriteLine(element.Text);
                if (text.Equals(element.Text))
                {
                    element.Click();
                    break;
                }
            }
            //foreach (var element in headerListElements)
            //{
            //    var str = element.FindElement(By.TagName("a")).Text;   
            //    if (text.Equals(element.FindElement(By.TagName("a")).Text))
            //    {
            //        element.Click();
            //        break;
            //    }
            //}
            //WaitWhileNotClickableWebElement(homePageLinkElement);
            //homePageLinkElement.Click();
            return new NewsPage(driver);
        }

        public LogInPage GoToLogInPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signInLinkElement.Click();
            return new LogInPage(driver);
        }

        public void ChangeLanguage(string value)
        {
            var selectElement = new SelectElement(changeLanguageSelectElement);
            selectElement.SelectByValue(value);
        }

        public IndexPage SignOut()
        {
            WaitWhileNotClickableWebElement(signOutButtonElement);
            signOutButtonElement.Click();
            return new IndexPage(driver);
        }

        public RegisterPage GoToRegistrationPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signUpLinkElement.Click();
            return new RegisterPage(driver);
        }

        public UserInfoPage GoToUserAccountPage()
        {
            WaitWhileNotClickableWebElement(userAccountManageLinkElement);
            userAccountManageLinkElement.Click();
            return new UserInfoPage(driver);
        }
    }
}