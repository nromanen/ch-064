using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM.Mail
{
    public class OutboxBlock : BasePageElement
    {
        public OutboxBlock()
        {

        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div:nth-child(3) > div.col-lg-3 > a:nth-child(2) > div")]
        public IWebElement OutboxElement { get; set; }

        public IWebElement Header { get; set; }
        public IWebElement Message { get; set; }

        public void OutboxElementClick()
        {
            OutboxElement.Click();
        }

    }
}
