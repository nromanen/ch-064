using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public abstract class BasePageElement
    {
        IWebDriver driver;
        public BasePageElement(IWebElement context)
        {
            PageFactory.InitElements(context, this);
        }

        public BasePageElement()
        {

        }

        internal void SetDriver(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
