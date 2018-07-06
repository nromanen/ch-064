using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected ExtendedWebDriver extendedDriver;

        protected BaseTest()
        {
            //extendedDriver = DriversFabric.InitChrome();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constants.HOME_URL);

        }

        public void BeginTest()
        {
            driver.Navigate().GoToUrl(Constants.HOME_URL);
        }

        public T ConstructPage<T>()where T: BasePage, new()
        {
            var page = new T();
            page.SetDriver(driver);

            try
            {
                PageFactory.InitElements(driver, page);
                return page;
            } catch (Exception e)
            {
                return null;
            }
        }

        public T ConstructPageElement<T>(IWebElement pageElement) where T : BasePageElement, new()
        {
            var element = new T();
            element.SetDriver(driver);
            try
            {
                PageFactory.InitElements(pageElement, element);
                return element;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public virtual void Dispose()
        {
            driver?.Dispose();
            extendedDriver?.Dispose();
        }
    }
}