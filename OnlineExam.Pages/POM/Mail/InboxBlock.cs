using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.IO;
using System.Runtime.InteropServices;
using OnlineExam.Pages.POM.Mail;

namespace OnlineExam.Pages.POM.Mail
{
    public class InboxBlock : BasePageElement
    {
        public InboxBlock()
        {

        }

        [FindsBy(How = How.CssSelector, Using = "#InBoxMEssages > p")]
        public IList<IWebElement> InboxMailList { get; set; }

        public IWebElement Header { get; set; }
        public IWebElement Message { get; set; }

        public IList<InboxBlock> GetInboxBlocksList()
        {
            var inboxBlocksList = new List<InboxBlock>();
            for (var i =1; i < InboxMailList.Count; i = i + 2)
            {
                var block = new InboxBlock();
                block.SetDriver(this.driver);
                block.Header = InboxMailList[i];
                block.Message = InboxMailList[i + 1];
                inboxBlocksList.Add(block);
            }
            return inboxBlocksList;
        }

        public string GetInboxMail()
        {
            string result = "";
            var inboxBlocksList = GetInboxBlocksList();
            foreach (var block in inboxBlocksList)
            {
                result += block.Header.Text + " ";
            }
            return result;
        }

        public bool IsMailPresentedInInbox(string header)
        {
            var inboxBlocksList = GetInboxBlocksList();
            foreach (var block in inboxBlocksList)
            {
                if (block.Header.Text.StartsWith(header))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
