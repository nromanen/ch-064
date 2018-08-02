//using Newtonsoft.Json;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Edge;
//using OpenQA.Selenium.PhantomJS;
//using System.IO;

//namespace OnlineExam.Framework
//{
//    public enum Browsers
//    {
//        Chrome,
//        Phantom,
//        Edge
//    }

//    public class BasicSettings
//    {
//        public Browsers Browser { get; set; }
//        public string Url { get; set; }
//        public string ConnectionString { get; set; }
  

//        public BasicSettings(Browsers browser, string url, string connectionstring)
//        {
//            Browser = browser;
//            Url = url;
//            ConnectionString = connectionstring;
//        }
//    }


//    public class BaseSettings
//    {
//        public BasicSettings Deserialization()
//        {
//            StreamReader rdr = new StreamReader(@"ConfigFile.json");
//            JsonSerializer serializer = new JsonSerializer();
//            BasicSettings settings = (BasicSettings)serializer.Deserialize(rdr, typeof(BasicSettings));
//            BasicSettings bs = new BasicSettings(settings.Browser, settings.Url, settings.ConnectionString);
//            return bs;
//        }

//        public static string GetHomeUrl(BasicSettings settings)
//        {
//            return settings.Url;
//        }

//        public static string GetConnectionString(BasicSettings settings)
//        {
//            return settings.ConnectionString;
//        }

//        public static ExtendedWebDriver Init()
//        {
//            using (StreamReader file = File.OpenText(@"ConfigFile.json"))
//            {
//                JsonSerializer serializer = new JsonSerializer();
//                BasicSettings settings = (BasicSettings)serializer.Deserialize(file, typeof(BasicSettings));

//                if (settings.Browser.ToString().Equals("Chrome"))
//                {
//                    IWebDriver Chromedriver = new ChromeDriver();
//                    return new ExtendedWebDriver(Chromedriver);
//                }
//                else if (settings.Browser.ToString().Equals("Phantom"))
//                {
//                    IWebDriver Phantomdriver = new PhantomJSDriver();
//                    return new ExtendedWebDriver(Phantomdriver);
//                }
//                else if (settings.Browser.ToString().Equals("Edge"))
//                {
//                    IWebDriver Edgedriver = new EdgeDriver();
//                    return new ExtendedWebDriver(Edgedriver);
//                }
//                else
//                {
//                    IWebDriver Chromedriver = new ChromeDriver();
//                    return new ExtendedWebDriver(Chromedriver);
//                }
//            }
//        }    
//    }
//}

