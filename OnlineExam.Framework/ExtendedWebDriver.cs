using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Framework
{
    public class ExtendedWebDriver : IDisposable
    {
        private IWebDriver driver;
        public static TimeSpan WAIT_TIME = new TimeSpan(0, 0, 100);

        public ExtendedWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }


        public string URL => driver.Url;
        
        public ISearchContext SeleniumContext => driver;

        public void TakeScreenshot(string path)
        {
            var ss = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(path, ScreenshotImageFormat.Png); //use any of the built in image formating
            ss.ToString();//same as string screenshot = ss.AsBase64EncodedString;
        }

        public string GetCurrentUrl()
        {
           return driver.Url;
        }

        public void WaitWhileNotClickableWebElement(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void ExecuteJavaScript(string jsCode,IWebElement webElement0,IWebElement webElement1)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(jsCode, webElement0, webElement1);
        }

        public void Dispose()
        {
            driver.Dispose();
        }
    }
}