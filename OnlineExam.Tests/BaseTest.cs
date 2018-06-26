using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static OnlineExam.Tests.Properties.Settings;

namespace OnlineExam.Tests
{
    public abstract class BaseTest
    {
     
        protected IWebDriver driver;

        protected BaseTest()
        {
           
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Default.HOME_URL);
        }
    }
}