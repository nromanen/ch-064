using System;
using System.Collections.Generic;
using System.IO;
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
        static int ScreenCounter = 0; //Will be update per screenshot that we took
        private IWebDriver driver;
        public static TimeSpan WAIT_TIME = new TimeSpan(0,0,10);

        public ExtendedWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsCookieEnabled(string cookieName)
        {
            var result = driver.Manage().Cookies.GetCookieNamed(cookieName);
            return result != null;
        }

        public ISearchContext SeleniumContext => driver;

        public string TakesScreenshotWithDate(string Path, string FileName, ScreenshotImageFormat Format)
        {
            ScreenCounter++; //Updates the number of screenshots that we took during the execution

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");

            //Remember that we cannot save a file with '/' Or ':', but we still need a unique identifier, Therefore, we will make this simple replace.

            //    Before: 12 / 06 / 2015 14:54:55
            //After: 12_06_2015 14_54_55

            DirectoryInfo Validation = new DirectoryInfo(Path); //System IO object
            var ScreenShotPath = "..\\Screenshots" + ScreenCounter.ToString() + "." + FileName + TimeAndDate.ToString() + "." +
                                 Format;
            if (Validation.Exists == true) //Capture screen if the path is available
            {
                ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(ScreenShotPath, Format);
            }
            else //Create the folder and then Capture the screen
            {
                Validation.Create();
                ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(ScreenShotPath, Format);
            }

            return ScreenShotPath;
        }


        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public string GetCurrentTitle()
        {
            return driver.Title;
        }

        public void WaitWhileTextToBePresentInElement(IWebElement webElement,string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            //wait.Until(ExpectedConditions.TextToBePresentInElement(webElement,text));
            wait.Until(e => webElement.Text.Contains(text));
        }

        public void WaitWhileNotClickableWebElement(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            //wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            wait.Until(e => webElement.Displayed && webElement.Enabled);
        }

        public void WaitUntilElementExists(IWebElement webElement, string expectedStr)
        {
            WebDriverWait wait = new WebDriverWait(driver, WAIT_TIME);
            //wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, expectedStr));//  ElementExists(By.CssSelector(webElement)));
            wait.Until(e => webElement.Text.Contains(expectedStr));
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void ExecuteJavaScript(string jsCode, IWebElement webElement0, IWebElement webElement1)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript(jsCode, webElement0, webElement1);
        }

        public void ExecuteJavaScript(string jsCode, IWebElement webElement0)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(jsCode, webElement0);
        }

        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
           // driver.Quit();
            driver.Dispose();
        }
    }
}