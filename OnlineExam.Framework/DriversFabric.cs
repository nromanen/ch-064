using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;


namespace OnlineExam.Framework
{
    public class DriversFabric
    {
        public static ExtendedWebDriver Init()
        {
            switch (BaseSettings.Fields.Browser)
            {
                case (Browsers.IE):
                    IWebDriver IEDriver = new InternetExplorerDriver();
                    return new ExtendedWebDriver(IEDriver);
                case (Browsers.Edge):
                    IWebDriver Edgedriver = new EdgeDriver();
                    return new ExtendedWebDriver(Edgedriver);
                default:
                    IWebDriver Chromedriver = new ChromeDriver();
                    return new ExtendedWebDriver(Chromedriver);
            }
        }
    }
}
