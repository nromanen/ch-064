using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

//MISHA

namespace OnlineExam.Pages.POM
{

    public class SolutionCodePage : BasePage
    {
        public SolutionCodePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement MessageAboutreviewingSolution { get; set; }

        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement TaskDescription { get; set; }

        [FindsBy(How = How.CssSelector, Using = "CodeMirror-code")] //body > div > div > div.row.block2 > div > div > div > div.col-md-9 > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div > div > div.CodeMirror-code
        public IWebElement FieldForCode { get; set; }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement FieldWithResultOfCompilationCode { get; set; }

        [FindsBy(How = How.Id, Using = "executeButton")]
        public IWebElement ExecuteButton { get; set; }

        [FindsBy(How = How.Id, Using = "exit")]
        public IWebElement ExitButton { get; set; }

        [FindsBy(How = How.Id, Using = "done")]
        public IWebElement DoneButton { get; set; }


        public void FillingInFieldForCode(string CodeText)
        {
            FieldForCode.Clear();
            FieldForCode.SendKeys(CodeText);
        }

        public void ClickOnExecuteButton()
        {
            ExecuteButton.Click();
        }

        public void ClickOnExitButton()
        {
            ExitButton.Click();
        }

        public void ClickOnDoneButton()
        {
            DoneButton.Click();
        }

    }
}