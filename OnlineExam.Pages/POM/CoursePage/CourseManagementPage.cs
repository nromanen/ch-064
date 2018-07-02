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
        /// <summary>
        /// Course managment as teacher
        /// http://localhost:55842/CourseManagement
        /// </summary>

        public CourseManagementPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(1)")]
        public IWebElement AddCourseBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.btn:nth-child(2)")]
        public IWebElement MyCoursesBtn { get; set; }

        public bool IsExist(string CourseName)
        {
            IWebElement table = driver.FindElement(By.TagName("tbody"));

            IList<IWebElement> allRows = table.FindElements(By.TagName("tr"));

            foreach (IWebElement row in allRows)
            {
                IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                foreach (IWebElement cell in cells)
                {
                    if (cell.Text == CourseName)
                        return true;
                }
            }
            return false;
        }

        public void FollowLink()
        {
            IList<IWebElement> bluehighl = driver.FindElements(By.ClassName("bluehighl"));
            foreach (var item in bluehighl)
            {
                if (item.Text == "Check")
                    item.Click();
            }
        }

        public string ChangeOwner(string courseName)
        {
            //TODO: CHANGE OWNER follow link
            string tmpLink = "";
            var rows = driver.FindElements(By.TagName("tr"));
            foreach (var row in rows)
            {
                if (row.Text.Contains(courseName))
                {
                    //MessageBox.Show(row.Text);
                    IList<IWebElement> List = row.FindElements(By.TagName("a"));
                    foreach (var item in List)
                    {
                       // MessageBox.Show(item.Text);
                        if (item.Text.Equals("Змінити власника курсу") || item.Text.Equals("Change course owner"))
                        {
                            var link = item.GetAttribute("href");
                            //item.FindElement(By.LinkText(link)).Click();
                            //driver.Navigate().GoToUrl(link);
                            tmpLink = link;

                        }
                    }
                }
            }
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
