using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace OnlineExam.Pages.POM
{
    public class TeacherExerciseManagerPage : BasePage
    {
        public TeacherExerciseManagerPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.TagName, Using = "tr")]
        public IList<IWebElement> RowOfTrs { get; set; }

        [FindsBy(How = How.Id, Using = "bluhighl")]
        public IList<IWebElement> RowOfIDS { get; set; }

        [FindsBy(How =How.Id, Using = "bluhighl")]
        public IWebElement TaskNameId { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-default")]
        public IWebElement ChangeButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-danger")]
        public IWebElement DeleteButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn btn-sm btn-default col-md-3")]
        public IWebElement SolutionButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div > div > h4 > a")]
        public IWebElement AddTaskButton { get; set; }

        public bool IsTaskAvailable(string TaskName)
        {
          
            foreach (var id in RowOfIDS)
            {
                var text = id.Text;
                if (text.Equals(TaskName))
                {
                    return true;
                }
            }
                
            return false;
        }

        public void ClickOnChangeButton(string TaskName)
        {
            foreach (var id in RowOfIDS)
            {
                var text = id.Text;
                if (text.Equals(TaskName))
                {
                    ChangeButton.Click();
                    break;
                }
            }
        }

        public void ClickOnDeleteButton(string TaskName)
        {
            foreach(var tr in RowOfTrs)
            {
                var hz = tr.Text;
                MessageBox.Show(hz);
                foreach (var id in RowOfIDS)
                {
                var text = id.Text;
                if (text.Equals(TaskName))
                {
                    DeleteButton.Click();
                    break;
                }
                }
            }
        }

        public void ClickOnSolutionsButton(string TaskName)
        {
            foreach (var id in RowOfIDS)
            {
                var text = id.Text;
                if (text.Equals(TaskName))
                {
                    SolutionButton.Click();
                    break;
                }
            }
        }

        public void ClickOnAddTaskbutton()
        {
            AddTaskButton.Click();
        }

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