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

        /// <summary>
        /// Check if sign in element is available
        /// </summary>
        /// <returns></returns>
        public bool GetSignInElement()
        {
            return signInLinkElement.Displayed;
        }

        /// <summary>
        /// Get user name frome header
        /// </summary>
        /// <returns></returns>
        public string GetHeaderUserName()
        {
            return userAccountManageLinkElement.Text;
        }

        /// <summary>
        /// Get text from signIn button
        /// </summary>
        /// <returns></returns>
        public string GetSignInButtonText()
        {
            return signInLinkElement.Text;
        }

        /// <summary>
        /// Click on the home page link element, and go to the home page
        /// </summary>
        /// <returns></returns>
        public NewsPage GoToHomePage()
        {
            WaitWhileNotClickableWebElement(homePageLinkElement);
            homePageLinkElement.Click();
            return ConstructPage<NewsPage>();
        }
        /// <summary>
        /// Click on the signIn link element, and go to the login page
        /// </summary>
        /// <returns></returns>
        public LogInPage GoToLogInPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signInLinkElement.Click();
            return ConstructPage<LogInPage>();
        }

        /// <summary>
        /// Change language in header select element
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Header ChangeLanguage(string value)
        {
            var selectElement = new SelectElement(changeLanguageSelectElement);
            selectElement.SelectByValue(value);
            return this;
        }

        /// <summary>
        /// sign out from the system by clicking on sign out button
        /// </summary>
        /// <returns>IndexPage</returns>
        public IndexPage SignOut()
        {
            WaitWhileNotClickableWebElement(signOutButtonElement);
            signOutButtonElement.Click();
            return ConstructPage<IndexPage>();
        }

        /// <summary>
        /// Go to registration page by clicking on signUp link element
        /// </summary>
        /// <returns>RegisterPage</returns>
        public RegisterPage GoToRegistrationPage()
        {
            WaitWhileNotClickableWebElement(signInLinkElement);
            signUpLinkElement.Click();
            return ConstructPage<RegisterPage>();
        }

        /// <summary>
        /// Go to user account page by clicking on userAccount link element
        /// </summary>
        /// <returns>UserInfoPage</returns>
        public UserInfoPage GoToUserAccountPage()
        {
            WaitWhileNotClickableWebElement(userAccountManageLinkElement);
            userAccountManageLinkElement.Click();
            return ConstructPage<UserInfoPage>();
        }

        /// <summary>
        /// Check if user email is presented in header
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get current language by checking select element in header
        /// </summary>
        /// <returns></returns>
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