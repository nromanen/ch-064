using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
  public abstract  class BasePage
    {
        protected ExtendedWebDriver driver;

        public BasePage()
        {

        }

        public void SetDriver(ExtendedWebDriver driver)
        {
            this.driver = driver;
        }

        public T ConstructPage<T>() where T : BasePage, new()
        {
            var page = new T();
            page.SetDriver(driver);

            try
            {
                PageFactory.InitElements(driver.SeleniumContext, page);
                return page;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public T ConstructPageElement<T>(IWebElement pageElement) where T: BasePageElement, new()
        {
            var element = new T();
            element.SetDriver(driver);
            try
            {
                PageFactory.InitElements(pageElement, element);
                return element;
            } catch (Exception e)
            {
                return null;
            }
        }

        public static TimeSpan WAIT_TIME = new TimeSpan(0, 0, 100);


        public  void WaitWhileNotClickableWebElement(IWebElement webElement)
        {
            throw new Exception("Rewrite with using ExtendedWebDriver");
            //WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            //wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public string GetText(IWebElement element)
        {
            throw new Exception("Avoid using this logic");
        }

        public string GetCurrentUrl()
        {
            throw new Exception("Rewrite with using ExtendedWebDriver");
        }
    }
}
