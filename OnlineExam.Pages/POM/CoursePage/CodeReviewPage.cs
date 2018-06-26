using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class CodeReviewPage : BasePage
    {
        /// <summary>
        /// http://localhost:55842/Code/CodeReview
        /// </summary>

        public CodeReviewPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement ResultBlock { get; set; }

        [FindsBy(How = How.Id, Using = "executeButton")]
        public IWebElement ExecuteButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.row.block2 > div > div > div:nth-child(3) > div.col-md-9")]
        public IWebElement btnOK { get; set; }
    }
}
