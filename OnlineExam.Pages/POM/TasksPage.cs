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
    public class TasksPage : BasePage
    {

        public TasksPage() { }

        public IList<TasksPageRowItem> GetBlocks()
        {
            var blocks = new List<TasksPageRowItem>();
            foreach (var tr in RowOfTrs)
            {
                var block = ConstructPageElement<TasksPageRowItem>(tr);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        public TasksPageRowItem GetStarsCount(int countstars)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetStarsss(), countstars.ToString(), StringComparison.OrdinalIgnoreCase));
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
    }
}