using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Framework;
using OpenQA.Selenium;

namespace OnlineExam.Pages.POM
{
    public class IndexPage : BasePage
    {
        public IndexPage()
        {

        }

        /// <summary>
        /// Returns Index page.
        /// </summary>
        /// <returns></returns>
        public IndexPage GoToIndexPage()
        {
            driver.GoToUrl("http://localhost:55842");
            return ConstructPage<IndexPage>();
        }
    }
}
