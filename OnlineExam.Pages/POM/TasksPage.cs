using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnlineExam.Pages.POM.Tasks;

//MISHA

namespace OnlineExam.Pages.POM
{
    public class TasksPage : BasePage
    {

        public TasksPage() { }

        public TasksPage(IWebDriver driver) : base(driver)
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

        public TasksPageRowItem GetByName(string name)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetName(), name, StringComparison.OrdinalIgnoreCase));
        }

        public TasksPageRowItem GetByTasksButton (string name)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetButtonText(), name, StringComparison.OrdinalIgnoreCase));
        }


        [FindsBy(How = How.TagName, Using = "a")]
        public IList<IWebElement> TTTaskButton { get; set; }

        [FindsBy(How =How.TagName, Using ="td")]
        public IList<IWebElement> RowofTasksNames { get; set; }


      

        public bool IsTaskAvailable(string TaskName)
        {
            int i = 0;
            foreach (var tr in RowOfTrs)
            {
                    var td = RowofTasksNames; 
                    var taskname = td[i].Text; i +=3;
                MessageBox.Show(taskname);
                    if (taskname.Equals(TaskName))
                    {
                        return true;
                    }               
            }

            return false;
        }


        public void ClickOnTasksButton(string TaskName)
        {

            int i = 0; bool flag = false; int j = 4;
            foreach (var tr in RowOfTrs)
            {
                var td = RowofTasksNames;
                var taskname = td[i].Text; i += 3; j++;
                MessageBox.Show(taskname);
                if (taskname.Equals(TaskName))
                {
                    flag = true;
                }

                if (flag)
                {
                    MessageBox.Show("YPA");
                    var button = TTTaskButton;
                    button[j].Click();
                    break;
                }
            }

        }


    }
}