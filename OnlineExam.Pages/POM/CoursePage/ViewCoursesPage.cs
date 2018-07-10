using OnlineExam.Pages.POM.CoursePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExam.Pages.POM
{
    public class ViewCoursesPage : BasePage
    {
        // Created by Roma ༼ つ ◕_◕ ༽つ
        /// http://localhost:55842/CourseManagement/ViewCourses

        public ViewCoursesPage() { }

        [FindsBy(How = How.CssSelector, Using = ".container > a:nth-child(1)")]
        public IWebElement BtnAddCourse { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        public IList<ViewCoursesPageItem> RowItems { get; set; }

        public ViewCoursesPageItem GetByName(string name)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetCourseName(), name, StringComparison.OrdinalIgnoreCase));
        }

        public IList<ViewCoursesPageItem> GetBlocks()
        {
            var blocks = new List<ViewCoursesPageItem>();
            foreach (var tr in RowOfTrs)
            {
                var block = ConstructPageElement<ViewCoursesPageItem>(tr);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }
    }
}

