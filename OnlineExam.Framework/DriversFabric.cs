using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace OnlineExam.Framework
{
    public class DriversFabric
    {
        public static ExtendedWebDriver Init()
        {
            if (BaseSettings.fields.Browser.Equals(Browsers.Chrome))
            {
                IWebDriver Chromedriver = new ChromeDriver();
                return new ExtendedWebDriver(Chromedriver);
            }
            //else if (BaseSettings.fields.Browser.Equals(Browsers.Phantom))
            //{
            //    IWebDriver Phantomdriver = new PhantomJSDriver();
            //    return new ExtendedWebDriver(Phantomdriver);
            //}
            else if (BaseSettings.fields.Browser.Equals(Browsers.Edge))
            {
                IWebDriver Edgedriver = new EdgeDriver();
                return new ExtendedWebDriver(Edgedriver);
            }
            else
            {
                IWebDriver Chromedriver = new ChromeDriver();
                return new ExtendedWebDriver(Chromedriver);
            }
        }
    }
}
