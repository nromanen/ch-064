using OnlineExam.Pages.POM.CoursePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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
        private IWebElement BtnAddCourse { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        private IList<IWebElement> RowOfTrs { get; set; }

        private IList<ViewCoursesPageItem> RowItems { get; set; }

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

        public void ClickRestoreBtn(string courseName)
        {
            var block = GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (firstBlock != null)
                {
                    firstBlock.ClickBtnRecover();
                }
            }
        }

        public string IsDeleted(string courseName, ResourceManager rm)
        {
            var page = ConstructPage<ViewCoursesPage>();
            var blockList = page.GetBlocks();
            if (blockList != null)
            {
                var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (singleBlock != null && (singleBlock.GetBtnDeleteText().Equals(rm.GetString("btnDeleteCourse"))))
                {
                    singleBlock.ClickBtnDelete();
                    string buttontText = singleBlock.ClickDeleteBtn(courseName, page);
                    return buttontText;
                }
            }
            return null;
        }

        public string IsRestored(ViewCoursesPage page, string courseName, ResourceManager rm)
        {
            var blockList = page.GetBlocks();
            if (blockList != null)
            {
                var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (singleBlock != null && (singleBlock.GetBtnDeleteText().Equals(rm.GetString("btnRecoverCourse"))))
                {
                    singleBlock.ClickBtnDelete();
                    string buttontText = singleBlock.ClickRestoreBtn(courseName, page);
                    return buttontText;
                }
            }
            return String.Empty;
        }

        public void ClickChangeBtn(string courseName)
        {
            var block = GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (firstBlock != null)
                {
                    firstBlock.ClickBtnChange();
                }
            }
        }

        public void ClickChangeOwnerBtn(string courseName)
        {
            var block = GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (firstBlock != null)
                {
                    firstBlock.ClickBtnChangeOwner();
                }
            }
        }
     
        public bool IsCourseExist(string courseName)
        {
            var blockList = ConstructPage<ViewCoursesPage>().GetBlocks();
            if (blockList != null)
            {
                return blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase)) != null;
            }
            return false;
        }
    }
}

