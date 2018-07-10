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

        public IWebElement Header { get; set; }
        public IWebElement Message { get; set; }

        /// <summary>
        /// Returns text of Header (email and date)
        /// </summary>
        /// <returns></returns>
        public string GetHeaderText()
        {
            return Header.Text;
        }

        /// <summary>
        /// Returns text of Message
        /// </summary>
        /// <returns></returns>
        public string GetMessageText()
        {
            return Message.Text;
        }

        /// <summary>
        /// Compares text from message to actual text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsEqualText(string text)
        {
            return GetMessageText().Trim().Equals(text.Trim(), StringComparison.OrdinalIgnoreCase);
        }

    }
}
