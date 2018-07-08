using OnlineExam.Pages.POM.UserDetails;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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


        public Header()
        {
        }

        public Header(IWebDriver driver) : base(driver)
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
            //return new NewsPage(driver);
            throw new Exception("Rewrite using Page constructor");
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
    }
}