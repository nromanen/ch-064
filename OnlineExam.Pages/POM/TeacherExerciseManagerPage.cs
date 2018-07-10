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


        public IList<TeacherExerciseManagerPageRowItem> GetBlocks()
        {
            var blocks = new List<TeacherExerciseManagerPageRowItem>();
            foreach (var row in RowOfTrs)
            {
                var block = ConstructPageElement<TeacherExerciseManagerPageRowItem>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }


        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr td")]
        public IList<IWebElement> RowOfTds { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr td")]
        public IWebElement Tds { get; set; }

        public IList<TeacherExerciseManagerPageRowItem> RowItems { get; set; }


        public TeacherExerciseManagerPageRowItem GetByName(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetName(), TaskName, StringComparison.OrdinalIgnoreCase));
        }

        public TeacherExerciseManagerPageRowItem GetCreationDate(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetCreationDate(), TaskName, StringComparison.OrdinalIgnoreCase));
        }

        public TeacherExerciseManagerPageRowItem GetUpgradeDate(string TaskName)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.TEMP_GetUpdateDate(), TaskName, StringComparison.OrdinalIgnoreCase));
        }

        public TeacherExerciseManagerPageRowItem deleted ()
        {
            return RowItems.First(x => String.IsNullOrEmpty(x.TEMP_GetCourseName()));
        }



        [FindsBy( How = How.CssSelector, Using = "body > div > div > h4 > a")]
        public IWebElement AddTaskButton { get; set; }

        public void ClickOnAddTaskbutton()
        {
           AddTaskButton.Click();
        }

      
    }
}