using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
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
            //extendedDriver = DriversFabric.InitChrome();
            driver = new ChromeDriver();
        }

        public void BeginTest()
        {
            driver.Navigate().GoToUrl(Constants.HOME_URL);
        }

        public virtual void Dispose()
        {
            driver?.Dispose();
            extendedDriver?.Dispose();
        }
    }
}