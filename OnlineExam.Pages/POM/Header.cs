using OnlineExam.Pages.POM.UserDetails;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Globalization;
using System.Resources;
using System.Threading;
using OnlineExam.Framework;

namespace OnlineExam.Pages.POM
{
    public class Header : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#requestCulture_RequestCulture_UICulture_Name")]
        private IWebElement changeLanguageSelectElement;

        [FindsBy(How = How.CssSelector,
            Using = "#gn-menu > li:nth-child(2) > a")]
        private IWebElement homePageLinkElement;

        [FindsBy(How = How.CssSelector, Using = ".btn")]
        private IWebElement signOutButtonElement;

        [FindsBy(How = How.CssSelector, Using = @"[href*='/Account/Login']")]
        private IWebElement signInLinkElement;

        [FindsBy(How = How.CssSelector, Using = @"[href*='/Account/Register']")]
        private IWebElement signUpLinkElement;

        [FindsBy(How = How.CssSelector, Using = "#gn-menu > li:nth-child(3) > a:nth-child(1)")]
        private IWebElement userAccountManageLinkElement;

        private ResourceManager resxManager;
        private CultureInfo langInfo;

        public Header()
        {
        }


        public bool GetSignInElement()
        {
            return signInLinkElement.Displayed;
        }

        public string GetHeaderUserName()
        {
            return userAccountManageLinkElement.Text;
        }

        public string GetSignInButtonText()
        {
            return signInLinkElement.Text;
        }

        public NewsPage GoToHomePage()
        {
            WaitWhileNotClickableWebElement(homePageLinkElement);
            homePageLinkElement.Click();
            return ConstructPage<NewsPage>();
        }

        public LogInPage GoToLogInPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signInLinkElement.Click();
            return ConstructPage<LogInPage>();
        }

        public Header ChangeLanguage(string value)
        {
            var selectElement = new SelectElement(changeLanguageSelectElement);
            selectElement.SelectByValue(value);
            return this;
        }

        public IndexPage SignOut()
        {
            WaitWhileNotClickableWebElement(signOutButtonElement);
            signOutButtonElement.Click();
            return ConstructPage<IndexPage>();
        }

        public RegisterPage GoToRegistrationPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signUpLinkElement.Click();
            return ConstructPage<RegisterPage>();
        }

        public UserInfoPage GoToUserAccountPage()
        {
            WaitWhileNotClickableWebElement(userAccountManageLinkElement);
            userAccountManageLinkElement.Click();
            return ConstructPage<UserInfoPage>();
        }

        public bool IsUserEmailPresentedInHeader(string email)
        {
            Header header = ConstructPage<Header>();

            if (header.GetHeaderUserName() == email.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string assemblyPath = "OnlineExam.NUnitTests, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null";

        public ResourceManager GetCurrentLanguage()
        {
            SelectElement selectedValue = new SelectElement(changeLanguageSelectElement);
            string currentLanguage = selectedValue.SelectedOption.GetAttribute("value");
            if (currentLanguage.Equals(Constants.UKRAINE))
            {
                ResourceManager rm = new ResourceManager("OnlineExam.NUnitTests.lang.ua",
                    System.Reflection.Assembly.Load(assemblyPath));
                return rm;
            }

            if (currentLanguage.Equals(Constants.ENGLISH))
            {
                ResourceManager rm = new ResourceManager("OnlineExam.NUnitTests.lang.eng",
                    System.Reflection.Assembly.Load(assemblyPath));
                return rm;
            }

            return null;
        }
    }
}