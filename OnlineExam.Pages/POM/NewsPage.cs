using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class NewsPage : BasePage
    {
        public NewsPage()
        {
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/div/div[2]/a")]
        private IList<IWebElement> listOfNewsSort;

        [FindsBy(How = How.ClassName, Using = "col-lg-8")]//
        private IList<IWebElement> rowOfDivsNewsListElements;

        /// <summary>
        /// Checks if New(by title) is presented in list of news.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsNewsPresentedInNewsList(string title)
        {
            foreach (var row in rowOfDivsNewsListElements)
            {
                var text = row.FindElement(By.TagName("p")).Text;
                if (text.Equals(title))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
