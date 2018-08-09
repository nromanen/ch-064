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

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(3)")]
        private IWebElement CSharpStarterReference;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(5)")]
        private IWebElement CSharpEssentialReference;

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(7)")]
        private IWebElement CSharpAdvancedReference;

        [FindsBy(How = How.CssSelector, Using = ".row")]//
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
