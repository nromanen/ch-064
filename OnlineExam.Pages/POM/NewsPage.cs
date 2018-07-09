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
        public IWebElement CSharpStarterReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(5)")]
        public IWebElement CSharpEssentialReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(7)")]
        public IWebElement CSharpAdvancedReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".row")]//
        private IList<IWebElement> rowOfDivsNewsListElements;


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
