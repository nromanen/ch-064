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
        private IWebDriver driver;

        public ExtendedWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public ISearchContext SeleniumContext => driver;


        public void Dispose()
        {
            driver.Dispose();
        }
    }
}