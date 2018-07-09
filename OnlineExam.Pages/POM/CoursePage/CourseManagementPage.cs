using OnlineExam.Pages.POM.Tasks;
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
        /// http://localhost:55842/CourseManagement
        /// Created by Roma ༼ つ ◕_◕ ༽つ
        public CourseManagementPage(){ }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(1)")]
        public IWebElement BtnAddCourse { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(2)")]
        public IWebElement BtnMyCourses { get; set; }

        public void CreateCourse(string courseName, string courseDescription)
        {
            BtnAddCourse.Click();
            var createPage = ConstructPage<CreateCoursePage>();
            createPage.FillCourse(courseName,courseDescription);
            createPage.BtnOk.Click();
        }

        public bool IsExist(string CourseName)
        {
            var ListOfTasks = ConstructPage<CourseManagementPage>();
            var blocks = ListOfTasks.GetBlocks();
            var blocks1 = ListOfTasks.GetBlocks();
            //throw new Exception("Rewrite using Exteded driver");

            //IWebElement table = driver.FindElement(By.TagName("tbody"));

            //IList<IWebElement> allRows = table.FindElements(By.TagName("tr"));

            //foreach (IWebElement row in allRows)
            //{
            //    IList<IWebElement> cells = row.FindElements(By.TagName("td"));

            //    foreach (IWebElement cell in cells)
            //    {
            //        if (cell.Text == CourseName)
            //            return true;
            //    }
            //}
            //return false;
            return true;
            
        }
        [FindsBy(How = How.CssSelector, Using = ".table td:not(:first-of-type)")]
        public IList<IWebElement> RowOfTrs { get; set; }

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

        public void FollowLink()
        {
            //IList<IWebElement> bluehighl = driver.FindElements(By.ClassName("bluehighl"));
            //foreach (var item in bluehighl)
            //{
            //    if (item.Text == "Check")
            //        item.Click();
            //}
            throw new Exception("Rewrite using Extended web driver");
        }

        public string ChangeOwner(string courseName)
        {
           
            string tmpLink = "";
            //var rows = driver.FindElements(By.TagName("tr"));
            //foreach (var row in rows)
            //{
            //    if (row.Text.Contains(courseName))
            //    {
            //        //MessageBox.Show(row.Text);
            //        IList<IWebElement> List = row.FindElements(By.TagName("a"));
            //        foreach (var item in List)
            //        {
            //           // MessageBox.Show(item.Text);
            //            if (item.Text.Equals("Змінити власника курсу") || item.Text.Equals("Change course owner"))
            //            {
            //                var link = item.GetAttribute("href");
            //                //item.FindElement(By.LinkText(link)).Click();
            //                //driver.Navigate().GoToUrl(link);
            //                tmpLink = link;

            //            }
            //        }
            //    }
            //}
            throw new Exception("Rewrite using Extended user");
            return tmpLink;
        }

        public void Wait(IWebElement item)
        {
            bool breakIt = true;
            while (true)
            {
                breakIt = true;
                try
                {
                    item.Click();
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("element is not attached"))
                    {
                        breakIt = false;
                    }
                }
                if (breakIt)
                {
                    break;
                }

            }
        }

    }
}
