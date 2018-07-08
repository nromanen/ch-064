using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class ChangeRolePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "button.btn:nth-child(3)")]
        private IWebElement saveButtonElement;

        [FindsBy(How = How.CssSelector, Using = "div.col-lg-6:nth-child(3) > div:nth-child(3)")]
        private IWebElement currentRoleOfUserDivElement;

        [FindsBy(How = How.Name, Using = "roles")]
        private IList<IWebElement> radioButtonsChangeRoleOfUserListElements;

        [FindsBy(How = How.CssSelector, Using = "div.col-lg-6:nth-child(2) > h3:nth-child(1)")]
        private IWebElement currentUserEmailH2Element;

        public ChangeRolePage()
        {
        }

        public string CurrentRole()
        {
            return currentRoleOfUserDivElement.Text;
        }

        public void ChangeRole(string role)
        {
            foreach (var radio in radioButtonsChangeRoleOfUserListElements)
            {
                string sValue = radio.GetAttribute("value");

                if (sValue.Equals(role))
                {
                    driver.ExecuteJavaScript(
                        "arguments[0].click();" +
                        "arguments[1].click();",radio,saveButtonElement);
                    break;
                }
            }
        }
    }
}