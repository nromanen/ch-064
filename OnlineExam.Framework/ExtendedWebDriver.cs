using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExam.Framework
{
    public class ExtendedWebDriver : IDisposable
    {
        public ExtendedWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            this.driver.Navigate().GoToUrl(url);
        }


        private IWebDriver driver;

        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
