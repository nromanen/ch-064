using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

//MISHA

namespace OnlineExam.Pages.POM
{
    public class AddTaskAsTeacherPage : BasePage
    {

        public AddTaskAsTeacherPage() { }

        [FindsBy(How = How.Id, Using = "CourseId")]
        public IWebElement ListofCourses { get; set; }

        [FindsBy(How = How.Id, Using = "TaskName")]
        public IWebElement AddTaskName { get; set; }

        [FindsBy(How =How.Id, Using = "tinymce")]
        public IWebElement AddDescriptionToTheNewTask { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.row > div.col-md-6 > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div > div > div.CodeMirror-cursors")]
        public IWebElement FieldForBaseCode { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.row > div:nth-child(2) > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div > div > div.CodeMirror-code > div")]
        public IWebElement FieldForTestCasesCode { get; set; }

        [FindsBy(How =How.CssSelector, Using = "body > div > div > form > div:nth-child(8) > button")]
        public IWebElement AddButton { get; set; }

        [FindsBy(How =How.Id, Using = "runCode")]
        public IWebElement RunButton { get; set; }


        public void ChooseCourse(string CourseName)
        {
            var selectelement = new SelectElement(ListofCourses);
            selectelement.SelectByText(CourseName);
        }

        public void AddTaskNameForNewTask(string NewTaskName)
        {
            AddTaskName.SendKeys(NewTaskName);
        }

        public void AddDescriptionForNewTask(string DescriptionForNewTask)
        {
            AddDescriptionToTheNewTask.SendKeys(DescriptionForNewTask);
        }

        public void AddBaseCodeForNewTask(string BaseCode)
        {
            FieldForBaseCode.SendKeys(BaseCode);
            
        }

        public void AddTestCasesCode (string TestCaseCode)
        {
            FieldForTestCasesCode.SendKeys(TestCaseCode);
        }

        public void ClickOnAddButton()
        {
            AddButton.Click();
        }

        public void ClickOnRunButton()
        {
            RunButton.Click();
        }
    }
}
