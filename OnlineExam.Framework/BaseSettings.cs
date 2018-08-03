using System.IO;
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
    public class BasicSettingsFromJSON
    {
        public Browsers Browser { get; set; }
        public string Url { get; set; }
        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
    }

    public class BasicSettings
    {
        public Browsers Browser { get; set; }
        public string Url { get; set; }
        public string ConnectionString { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName{ get; set; }

        public BasicSettings()
        {
            using (StreamReader file = File.OpenText(@"D:\ch-064\ConfigFile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var settings = (BasicSettingsFromJSON)serializer.Deserialize(file, typeof(BasicSettingsFromJSON));
                Browser = settings.Browser;
                Url = settings.Url;
                ConnectionString = settings.ConnectionString;
                ServerName = settings.ServerName;
                DatabaseName = settings.DatabaseName;
            } 
        }
    }


    public class BaseSettings : BasicSettings
    {
        public static string GetHomeUrl()
        {
            BaseSettings bs = new BaseSettings();
            return bs.Url;
        }

        public static string GetConnectionString()
        {
            BaseSettings bs = new BaseSettings();
            return bs.ConnectionString;
        }

        public static string GetServerName()
        {
            BaseSettings bs = new BaseSettings();
            return bs.ServerName;
        }

        public static string GetDatabaseName()
        {
            BaseSettings bs = new BaseSettings();
            return bs.DatabaseName;
        }

        public static ExtendedWebDriver Init()
        {
                BaseSettings bs = new BaseSettings();
                if (bs.Browser.ToString().Equals("Chrome"))
                {
                    IWebDriver Chromedriver = new ChromeDriver();
                    return new ExtendedWebDriver(Chromedriver);
                }
                else if (bs.Browser.ToString().Equals("Phantom"))
                {
                    IWebDriver Phantomdriver = new PhantomJSDriver();
                    return new ExtendedWebDriver(Phantomdriver);
                }
                else if (bs.Browser.ToString().Equals("Edge"))
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

