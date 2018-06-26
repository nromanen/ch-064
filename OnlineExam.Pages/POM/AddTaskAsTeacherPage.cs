using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    class AddTaskAsTeacherPage : BasePage
    {
        public AddTaskAsTeacherPage(IWebDriver driver) : base(driver)
        {
        }

  
        [FindsBy(How = How.Id, Using = "CourseId")]
        public IWebElement ListofCoursesInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How = How.Id, Using = "TaskName")]
        public IWebElement AddTaskNameInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How =How.Id, Using = "tinymce")]
        public IWebElement AddDescriptionToTheNewTaskInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.row > div.col-md-6 > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div")]
        public IWebElement FieldForBaseCodeInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > form > div.row > div:nth-child(2) > div > div.CodeMirror-scroll > div.CodeMirror-sizer > div > div")]
        public IWebElement FieldForTestCasesCodeInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How =How.ClassName, Using = "btn btn-default")]
        public IWebElement AddButtonInAddTaskAsTeacherPage { get; set; }

        [FindsBy(How =How.Id, Using = "runCode")]
        public IWebElement RunButtonInAddTaskAsteacherPage { get; set; }


        public void ChooseCourseAddTaskAsTeacherPage(string CourseName)
        {
            //ListofCoursesInAddTaskAsTeacherPage.Click();
            //var selectElement = new SelectElement(CourseId);
            //selectElement.SelectByText(CourseName);

            //// select the drop down list
            //var education = driver.FindElement(By.Name("education"));
            ////create select element object 
            //var selectElement = new SelectElement(education);

            ////select by value
            //selectElement.SelectByValue("Jr.High");
            //// select by text
            //selectElement.SelectByText("HighSchool");
        }

        public void AddTaskNameForNewTaskInAddTaskAsTeacherPage(string NewTaskName)
        {
            AddTaskNameInAddTaskAsTeacherPage.SendKeys(NewTaskName);
        }

        public void AddDescriptionForNewTaskInAddTaskAsTeacherPage(string DescriptionForNewTask)
        {
            AddDescriptionToTheNewTaskInAddTaskAsTeacherPage.SendKeys(DescriptionForNewTask);
        }

        public void AddBaseCodeForNewTaskInAddTaskAsTeacherPage(string BaseCode)
        {
            FieldForBaseCodeInAddTaskAsTeacherPage.SendKeys(BaseCode);
        }

        public void AddTestCasesCodeInAddTaskAsTeacherPage (string TestCaseCode)
        {
            FieldForTestCasesCodeInAddTaskAsTeacherPage.SendKeys(TestCaseCode);
        }

        public void ClickOnAddButtonInAddTaskAsteacherPage()
        {
            AddButtonInAddTaskAsTeacherPage.Click();
        }

        public void ClickOnRunButton()
        {
            RunButtonInAddTaskAsteacherPage.Click();
        }
    }
}
