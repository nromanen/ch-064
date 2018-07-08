using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OnlineExam.Pages.POM
{
    public class IndexPage : BasePage
    {
        public IndexPage()
        {

        }

        public IndexPage GoToIndexPage()
        {
            //driver.Navigate().GoToUrl("http://localhost:55842");
            //return new IndexPage(driver);
            throw new Exception("Rewrite using Extebded driver");
        }
    }
}
