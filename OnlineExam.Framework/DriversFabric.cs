using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;

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
        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }

        public BasicSettings(Browsers browser, string url, string connectionstring)
        {
            Browser = browser;
            Url = url;
            ConnectionString = connectionstring;
        }
    }

    public class DriversFabric
    {
        private static string JSONPATH = @"D:\workspace\Academy tasks\OnlineExamTest\ConfigFile.json";

        public static string GetHomeUrl()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.Url;
            }
        }

        public static string GetBrowser()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.Browser.ToString();
            }
        }

        public static string GetConnectionString()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.ConnectionString.ToString();
            }
        }

        public static string GetServerName()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.ServerName.ToString();
            }
        }

        public static string GetDatabaseName()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
            {
                JsonSerializer serializer = new JsonSerializer();
                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));
                return settings.DatabaseName.ToString();
            }
        }

        public static ExtendedWebDriver Init()
        {
            using (StreamReader file = File.OpenText(JSONPATH))
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
                else if (settings.Browser.ToString().Equals("Edge"))
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
