using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM
{

    class SolutionCodePage : BasePage
    {
        public SolutionCodePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement MessageAboutreviewingSolutionInCodeSolutionPage { get; set; }

        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement TaskDescriptionInCodeSolutionPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "CodeMirror-code")] //body > div > div > div.row.block2 > div > div > div > div.col-md-9 > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div > div > div.CodeMirror-code
        public IWebElement FieldForCodeInCodeSolutionPage { get; set; }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement FieldWithResultOfCompilationCodeInCodeSolutionPage { get; set; }

        [FindsBy(How = How.Id, Using = "executeButton")]
        public IWebElement ExecuteButtonInCodeSolutionPage { get; set; }

        [FindsBy(How = How.Id, Using = "exit")]
        public IWebElement ExitButtonInCodeSolutionPage { get; set; }

        [FindsBy(How = How.Id, Using = "done")]
        public IWebElement DoneButtonInCodeSolutionPage { get; set; }


        public void FillingInFieldForCodeInCodeSolutionPage(string CodeText)
        {
            FieldForCodeInCodeSolutionPage.Clear();
            FieldForCodeInCodeSolutionPage.SendKeys(CodeText);
        }

        public void ClickOnExecuteButtonInCodeSolutionPage()
        {
            ExecuteButtonInCodeSolutionPage.Click();
        }

        public void ClickOnExitButtonInCodeSolutionPage()
        {
            ExitButtonInCodeSolutionPage.Click();
        }

        public void ClickOnDoneButtonInCodeSolutionPage()
        {
            DoneButtonInCodeSolutionPage.Click();
        }

    }
}
