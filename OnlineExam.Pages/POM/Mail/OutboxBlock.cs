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

        [FindsBy(How = How.CssSelector, Using = "#OutBoxMEssages > p")]
        public IList<IWebElement> OutboxMailList { get; set; }

        public IWebElement Header { get; set; }
        public IWebElement Message { get; set; }

        public string GetOutboxMail()
        {
            string result = "";
            var outboxBlocksList = GetOutboxBlocksList();
            foreach (var block in outboxBlocksList)
            {
                result += block.Header.Text + " ";
            }
            return result;
        }

        public bool IsMailPresentedInOutbox(string header)
        {
            var outboxBlocksList = GetOutboxBlocksList();
            foreach (var block in outboxBlocksList)
            {
                if (block.Header.Text.StartsWith(header))
                {
                    return true;
                }
            }
            return false;
        }

        public IList<OutboxBlock> GetOutboxBlocksList()
        {
            var outboxBlocksList = new List<OutboxBlock>();
            for (var i = 0; i < OutboxMailList.Count; i = i + 2)
            {
                var block = new OutboxBlock();
                block.SetDriver(this.driver);
                block.Header = OutboxMailList[i];
                block.Message = OutboxMailList[i + 1];
                outboxBlocksList.Add(block);
            }
            return outboxBlocksList;
        }

    }
}
