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
        public SolutionCodePage() { }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > div:nth-child(1) > div:nth-child(2)")]
        public IWebElement MessageAboutreviewingSolution { get; set; }
        
        [FindsBy(How = How.Id, Using = "tinymce")]
        public IWebElement TaskDescription { get; set; }

        [FindsBy(How = How.ClassName, Using = "CodeMirror")]
        public IWebElement FieldForCode { get; set; }

        [FindsBy(How = How.Id, Using = "result")]
        public IWebElement FieldWithResultOfCompilationCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"executeButton\"]")]
        public IWebElement ExecuteButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"exit\"]")]
        public IWebElement ExitButton { get; set; }

        [FindsBy(How = How.Id, Using = "done")]
        public IWebElement DoneButton { get; set; }

        /// <summary>
        /// Clear field for code and write your text
        /// </summary>
        /// <param name="CodeText"></param>
        public void FillingInFieldForCode(string CodeText)
        {
            FieldForCode.Clear();
            FieldForCode.SendKeys(CodeText);
        }

        /// <summary>
        /// Execute Button will be clicked on 
        /// </summary>
        public void ClickOnExecuteButton()
        {
            ExecuteButton.Click();
            //WaitWhileTextToBePresentInElement(FieldWithResultOfCompilationCode,text);
        }

        public void ClickOnExecuteButton(string text)
        {
            ExecuteButton.Click();
            WaitUntilTextIsPresentInElement(FieldWithResultOfCompilationCode,text);
        }


        public string GetTextFromFieldWithResultOfCompilationCode()
        {
            return FieldWithResultOfCompilationCode.Text;
        }
        /// <summary>
        /// Exit button will be clicked on
        /// </summary>
        public void ClickOnExitButton()
        {
            ExitButton.Click();
        }
        /// <summary>
        /// Done button will be clicked on
        /// </summary>
        public void ClickOnDoneButton()
        {
            DoneButton.Click();
        }


        public void SendKeysToFieldForCode(string keys)
        {
           // driver.ExecuteJavaScript("arguments[0].CodeMirror.setValue(\"\");",FieldForCode);
            driver.ExecuteJavaScript("arguments[0].CodeMirror.setValue(\"" + keys + "\");",FieldForCode);
        }
    }
}