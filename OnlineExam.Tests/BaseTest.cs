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
       // extendedDriver = DriversFabric.InitChrome();
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(Constants.HOME_URL);
    }

        public void Dispose()
        {
            driver.Dispose();
            extendedDriver?.Dispose();
        }
    }
}