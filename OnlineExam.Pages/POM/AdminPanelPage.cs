using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class AdminPanelPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".body-content > h2:nth-child(2)")]
        private IWebElement listOfUsersH2Element;

        [FindsBy(How = How.CssSelector, Using = ".row")]
        private IList<IWebElement> rowOfDivsUserListElements;

        public AdminPanelPage(IWebDriver driver) : base(driver)
        {
        }

        public AdminPanelPage()
        {
        }

        public void DeleteUser(string email)
        {
            foreach (var row in rowOfDivsUserListElements)
            {
                var text = row.FindElement(By.TagName("p")).Text;
                if (text.Equals(email))
                {
                    row.FindElement(By.TagName("button")).Click();
                    break;
                }
            }
        }


        public ChangeRolePage ChangeRoleOfUserButtonClick(string email)
        {
            foreach (var row in rowOfDivsUserListElements)
            {
                var text = row.FindElement(By.TagName("p")).Text;
                if (text.Equals(email))
                {
                    row.FindElement(By.TagName("a")).Click();
                    return ConstructPage<ChangeRolePage>();
                }
            }

            return null;
        }

        public bool IsUserPresentedInUserList(string email)
        {
            foreach (var row in rowOfDivsUserListElements)
            {
                var text = row.FindElement(By.TagName("p")).Text;
                if (text.Equals(email))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsListOfUsersH2ElementPresented()
        {
            if (listOfUsersH2Element.Displayed)
                return true;

            return false;
        }
    }
}