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
        public CourseManagementPage(){ }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(1)")]
        public IWebElement BtnAddCourse { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(2)")]
        public IWebElement BtnMyCourses { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".table tr:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

        public IList<CreateCoursePageRowItem> RowItems { get; set; }

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
            createPage.BtnOk.Click();
        }

        public void GoToCourse(string courseName)
        {
            var block = this.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));
                System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseName());
                System.Windows.Forms.MessageBox.Show(firstBlock.GetCourseCreatingDate());
                if (firstBlock != null)
                {
                    firstBlock.ClickOnCourseTitle();
                    
                }
            }
        }
    }
}
