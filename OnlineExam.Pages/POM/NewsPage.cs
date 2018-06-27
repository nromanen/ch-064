using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver)
        {
            allSections = base.driver.FindElements(By.ClassName("section")).ToList();
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(3)")]
        public IWebElement CSharpStarterReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(5)")]
        public IWebElement CSharpEssentialReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div > div > div.col-lg-4 > a:nth-child(7)")]
        public IWebElement CSharpAdvancedReference { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".row")]//
        protected IList<IWebElement> rowOfDivsNewsListElements;

        [FindsBy(How = How.CssSelector, Using = ".section")]
        public List<IWebElement> allSections;

        public NewsPage CheckCourse(int id)
        {
            driver.Navigate().GoToUrl("http://localhost:55842/AddNews/News");
            allSections[id - 1].Click();
            return new NewsPage(driver);
        }

    }
}
