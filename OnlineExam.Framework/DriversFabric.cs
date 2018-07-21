using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;
using Newtonsoft.Json;
using System.IO;

namespace OnlineExam.Framework
{
    public enum Browsers
    {
        Chrome,
        Phantom,
        Edge
    }

    public class BasicSettings
    {
        public Browsers Browser { get; set; }
        public string Url { get; set; }

        public BasicSettings(Browsers browser, string url)
        {
            Browser = browser;
            Url = url;
        }
    }

    public class DriversFabric
    {
        public static string GetHomeUrl()
        {
            using (StreamReader file = File.OpenText(@"ConfigFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.Url;
            }
        }

        public static string GetBrowser()
        {
            using (StreamReader file = File.OpenText(@"ConfigFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.Browser.ToString();
            }
        }



        public static ExtendedWebDriver Init()
        {
            using (StreamReader file = File.OpenText(@"ConfigFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));

                if (settings.Browser.ToString().Equals("Chrome"))
                {
                    IWebDriver Chromedriver = new ChromeDriver();
                    return new ExtendedWebDriver(Chromedriver);
                }
                else if (settings.Browser.ToString().Equals("Phantom"))
                {
                    IWebDriver Phantomdriver = new PhantomJSDriver();
                    return new ExtendedWebDriver(Phantomdriver);
                }
                else if(settings.Browser.ToString().Equals("Edge"))
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
}
