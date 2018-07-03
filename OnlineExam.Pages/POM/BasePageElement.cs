using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public abstract class BasePageElement
    {
        public IWebDriver driver;
        public BasePageElement()
        {

        }

        public void SetDriver(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}
