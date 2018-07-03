using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class MailBoxPage : BasePage
    {
        public MailBoxPage(IWebDriver driver) : base(driver)
        {
        }

        public MailBoxPage()
        {
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(1) > div")]
        public IWebElement InboxElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(2) > div")]
        public IWebElement OutboxElement { get; set; }

        [FindsBy(How = How.Id, Using = "InBoxMEssages")]
        private List <IWebElement> inboxList  { get; set; }

        //TODO записувати в док тексти
        public bool IsMailPresentedInMailList(string email)
        {
            foreach (var row in inboxList)
            {
                var text = row.FindElement(By.TagName("p")).Text;
                if (text.Equals(email))
                {
                    return true;
                }
            }

            return false;
        }
        

    }

}