using OnlineExam.Framework;
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
        protected ExtendedWebDriver driver;
        public BasePageElement(IWebElement context)
        {
            PageFactory.InitElements(context, this);
        }

        public BasePageElement()
        {

        }

        public void SetDriver(ExtendedWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
