using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{
    public class CodePage : BasePage
    {
        /// <summary>
        /// http://localhost:55842/Code
        /// </summary>

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement StatusMessageBlock { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ECMDIV")]
        public IWebElement TaskTestBlock { get; set; }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement TestsResultBlock { get; set; }

        [FindsBy(How = How.ClassName, Using = "CodeMirror-line")]
        public IWebElement SingleCodeLine { get; set; }

        [FindsBy(How = How.Id, Using = "codeText")]
        public IWebElement CodeText { get; set; }

        [FindsBy(How = How.Id, Using = "executeButton")]
        public IWebElement ExecuteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "exit")]
        public IWebElement ExitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "done")]
        public IWebElement DoneBtn { get; set; }
    }
}
