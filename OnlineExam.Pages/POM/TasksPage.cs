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
        /// <summary>
        /// all "tr" row will be placed in the list
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Searching first Row Item and it's stars count [rating] (from list of rows) with needed count of stars
        /// </summary>
        /// <param name="countstars"></param>
        /// <returns></returns>
        public TasksPageRowItem GetStarsCount(int countstars)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetStarsss(), countstars.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        public IList<TasksPageRowItem> RowItems { get; set; }
        /// <summary>
        /// Searching first Row Item and it's name (from list of rows) with needed task name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TasksPageRowItem GetByName(string name)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetName(), name, StringComparison.OrdinalIgnoreCase));
        }

    }
}