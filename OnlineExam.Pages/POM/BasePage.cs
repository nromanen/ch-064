using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
  public abstract  class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public static TimeSpan WAIT_TIME = new TimeSpan(0, 0, 100);


        public  void WaitWhileNotClickableWebElement(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

    }
}
