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

        public void TakeScreenshot(string path)
        {
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(path, ScreenshotImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
        }

        public string GetDriverTitle()
        {
            return driver.Title;
        }

        public string GetDriverURL()
        {
            return driver.Url;
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}