using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OnlineExam.Framework
{
    public class DriversFabric
    {
        public static ExtendedWebDriver InitChrome()
        {
            
            IWebDriver driver = new ChromeDriver();
            return  new ExtendedWebDriver(driver);
        }
    }
}
