using OnlineExam.Pages.POM.CoursePage;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExam.Pages.POM
{
    public class CourseManagementPage : BasePage
    {
        // http://localhost:55842/CourseManagement
        // Created by Roma ༼ つ ◕_◕ ༽つ
        public CourseManagementPage() { }
        ///html/body/div/div/a[1]
        [FindsBy(How = How.XPath, Using = "//a[@href='/CourseManagement/Create']")]
        private IWebElement BtnAddCourse { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/CourseManagement/ViewCourses']")]
        private IWebElement BtnMyCourses { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        private IList<IWebElement> RowOfTrs { get; set; }

        private IList<CreateCoursePageRowItem> RowItems { get; set; }

        public CreateCoursePageRowItem GetByName(string name)
        {
            return RowItems.FirstOrDefault(x => String.Equals(x.GetCourseName(), name, StringComparison.OrdinalIgnoreCase));
        }

        public IList<CreateCoursePageRowItem> GetBlocks()
        {
            var blocks = new List<CreateCoursePageRowItem>();
            foreach (var tr in RowOfTrs)
            {
                var block = ConstructPageElement<CreateCoursePageRowItem>(tr);
                if (block != null)
                    blocks.Add(block);
            }
            return blocks;
        }

        public void CreateCourse(string courseName, string courseDescription)
        {
            BtnAddCourse.Click();
            var createPage = ConstructPage<CreateCoursePage>();
            createPage.FillCourse(courseName, courseDescription);
            createPage.ClickBtnOk();
        }

        public void GoToCourse(string courseName)
        {
            var block = this.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                if (firstBlock != null)
                {
                    firstBlock.ClickOnCourseTitle();
                }
            }
        }

        public string GetCreatedCourseName(IList<CreateCoursePageRowItem> blockList, string courseName)
        {
            if (blockList != null)
            {
                var singleBlock = blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                return singleBlock.GetCourseName();
            }
            return String.Empty;
        }

        /// <summary>
        /// Returns true if created course presented in course list or false if not presented
        /// </summary>
        public bool IsCourseCreated(string courseName)
        {
            //IList<CreateCoursePageRowItem> blockList,
            var blockList = ConstructPage<CourseManagementPage>().GetBlocks();
            if (blockList != null)
            {
                return blockList.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase)) != null;
            }
            return false;
        }

        public void ClickBtnAddCourse()
        {
            BtnAddCourse.Click();
        }

        public void ClickBtnMyCourses()
        {
            BtnMyCourses.Click();
        }
    }
}
