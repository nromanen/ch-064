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

        

    }
}
