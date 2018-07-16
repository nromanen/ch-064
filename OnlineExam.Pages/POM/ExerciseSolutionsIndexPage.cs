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

namespace OnlineExam.Pages.POM
{
    public class ExerciseSolutionsIndexPage : BasePage
    {
        public ExerciseSolutionsIndexPage() { }

        /// <summary>
        /// all "tr" row will be placed in the list
        /// </summary>
        /// <returns></returns>
        public IList<ExerciseSolutionsIndexPageItem> GetBlocks()
        {
            var blocks = new List<ExerciseSolutionsIndexPageItem>();
            foreach (var row in RowOfTrs)
            {
                var block = ConstructPageElement<ExerciseSolutionsIndexPageItem>(row);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        public IList<ExerciseSolutionsIndexPageItem> RowItems { get; set; }

        public ExerciseSolutionsIndexPageItem GetByEmail(string Email)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetEmail(), Email, StringComparison.OrdinalIgnoreCase));
        }

    }
}
