using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    class TeacherExerciseManagerPage : BasePage
    {
        public TeacherExerciseManagerPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.TagName, Using = "tr")]
        public IList<IWebElement> RowOfTdsTaskNamesListElementsInExercisemanagment { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-default")]
        public IWebElement ChangeButtonInTeacherExercisemanagerPage { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-danger")]
        public IWebElement DeleteButtonInTeacherExercisemanagerPage { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-default col-md-3")]
        public IWebElement SolutionButtonInTeacherExercisemanagerPage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > h4 > a")]
        public IWebElement AddTaskButtonInTeacherExercisemanagerPage { get; set; }



        public void ClickOnChangeButtonInTeacherExercisemanagerPage(string TaskName)
        {
            foreach (var tr in RowOfTdsTaskNamesListElementsInExercisemanagment)
            {
                var text = tr.FindElement(By.Id("bluhighl")).Text;
                if (text.Equals(TaskName))
                {
                    ChangeButtonInTeacherExercisemanagerPage.Click();
                    break;
                }
            }
        }

        public void ClickOnDeleteButtonInTeacherExercisemanagerPage(string TaskName)
        {
            foreach (var tr in RowOfTdsTaskNamesListElementsInExercisemanagment)
            {
                var text = tr.FindElement(By.Id("bluhighl")).Text;
                if (text.Equals(TaskName))
                {
                    DeleteButtonInTeacherExercisemanagerPage.Click();
                    break;
                }
            }
        }

        public void ClickOnSolutionsButtonInTeacherExercisemanagerPage(string TaskName)
        {
            foreach (var tr in RowOfTdsTaskNamesListElementsInExercisemanagment)
            {
                var text = tr.FindElement(By.Id("bluhighl")).Text;
                if (text.Equals(TaskName))
                {
                    SolutionButtonInTeacherExercisemanagerPage.Click();
                    break;
                }
            }
        }

        public void ClickOnAddTaskbuttonInTeacherExercisemanagerPage()
        {
            AddTaskButtonInTeacherExercisemanagerPage.Click();
        }

        public void ClickOnTasknameInTeacherExercisemanagerPage(string TaskName)
        {
            foreach (var tr in RowOfTdsTaskNamesListElementsInExercisemanagment)
            {
                var text = tr.FindElement(By.Id("bluhighl")).Text;
                if (text.Equals(TaskName))
                {
                    tr.FindElement(By.Id("bluhighl")).Click();
                    break;
                }
            }
        }
    }
}
