using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExam.Tests
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected ExtendedWebDriver extendedDriver;

        protected BaseTest()
        {
            // extendedDriver = DriversFabric.InitChrome();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Constants.HOME_URL);
        }

        //public T InitPage<T>() where T : BasePage
        //{
        //    return new T(driver);
        //}

        public void Dispose()
        {
            driver.Dispose();
            extendedDriver?.Dispose();
        }
    }
}