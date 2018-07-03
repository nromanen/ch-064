using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OnlineExam.Pages.POM.Tasks;

//MISHA

namespace OnlineExam.Pages.POM
{
    public class TeacherExerciseManagerPage : BasePage
    {
        public TeacherExerciseManagerPage() { }

        public TeacherExerciseManagerPage(IWebDriver driver) : base(driver)
        {
            var rowItemsList = new List<TasksPageRowItem>();
            foreach (var tr in RowOfTrs)
            {
                var rowItem = new TasksPageRowItem(tr);
                rowItemsList.Add(rowItem);
            }
            RowItems = rowItemsList;
        }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        public IList<TasksPageRowItem> RowItems { get; set; }

       
        /// ///////////////////////
        [FindsBy(How = How.Id, Using = "bluhighl")]
        public IList<IWebElement> RowOfIDS { get; set; }
        /// ////////////////////

        public TasksPageRowItem GetByName(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetName(), TaskName, StringComparison.OrdinalIgnoreCase));
        }

        public TasksPageRowItem GetCreationDate(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetCreationDate(), TaskName, StringComparison.OrdinalIgnoreCase));
        }

        public TasksPageRowItem GetUpgradeDate(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetUpdateDate(), TaskName, StringComparison.OrdinalIgnoreCase));
        }



        //public void ClickOnChangeButton(string TaskName)
        //{
        //    foreach (var id in RowOfIDS)
        //    {
        //        var text = id.Text;
        //        if (text.Equals(TaskName))
        //        {
        //            ChangeButton.Click();
        //            break;
        //        }
        //    }
        //}

        //public void ClickOnDeleteButton(string TaskName)
        //{
        //    foreach(var tr in RowOfTrs)
        //    {
        //        var hz = tr.Text;
        //        MessageBox.Show(hz);
        //        foreach (var id in RowOfIDS)
        //        {
        //        var text = id.Text;
        //        if (text.Equals(TaskName))
        //        {
        //            DeleteButton.Click();
        //            break;
        //        }
        //        }
        //    }
        //}

        //public void ClickOnSolutionsButton(string TaskName)
        //{
        //    foreach (var id in RowOfIDS)
        //    {
        //        var text = id.Text;
        //        if (text.Equals(TaskName))
        //        {
        //            SolutionButton.Click();
        //            break;
        //        }
        //    }
        //}

        //public void ClickOnAddTaskbutton()
        //{
        //    AddTaskButton.Click();
        //}

        public void ClickOnTaskname(string TaskName)
        {
            foreach (var id in RowOfIDS)
            {
                var text = id.Text;
                if (text.Equals(TaskName))
                {
                    id.Click();
                    break;
                }
            }
        }
    }
}