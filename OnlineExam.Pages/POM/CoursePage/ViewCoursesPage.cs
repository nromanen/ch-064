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
        /// <summary>
        /// http://localhost:55842/CourseManagement/ViewCourses
        /// </summary>
        /// 
        public ViewCoursesPage()
        {
                
        }

        [FindsBy(How = How.CssSelector, Using = ".container > a:nth-child(1)")]
        public IWebElement AddCourseBtn { get; set; }

        public void DeleteCourse(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                //MessageBox.Show(item.Text);
                if (item.Text.Equals("Видалити") || item.Text.Equals("Delete"))
                    item.Click();
            }

        }

        public bool IsCourseDeleted(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                //MessageBox.Show(item.Text);
                if (item.Text.Equals("Відновити") || item.Text.Equals("Recover"))
                    return true;
            }
            return false;
        }

        public void RestoreCourse(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                if (item.Text.Equals("Відновити") || item.Text.Equals("Recover"))
                    item.Click();
            }
        }

        public bool IsCourseRestored(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                //MessageBox.Show(item.Text);
                if (item.Text.Equals("Видалити") || item.Text.Equals("Delete"))
                    return true;
            }
            return false;
        }

        public IList<IWebElement> FindCourse(string courseName)
        {
            //var rows = driver.FindElements(By.TagName("tr"));
            //foreach (var row in rows)
            //{
            //    if (row.Text.Contains(courseName))
            //    {
            //        IList<IWebElement> List = row.FindElements(By.TagName("a"));
            //        List<String> NewList = new List<String>();
            //        return List;
            //    }
            //}
            return null;
        }

        public void ChangeCourse(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                MessageBox.Show(item.Text);
                if (item.Text.Equals("Редагувати") || item.Text.Equals("Change"))
                {
                    #region trash
                    //IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(60000));
                    //var link = item.GetAttribute("href");
                    //wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(link)));
                    //string link = item.GetAttribute("href");
                    //MessageBox.Show(link);
                    //item.Click();
                    //MessageBox.Show(item.Text);
                    //MessageBox.Show(link);
                    WaitWhileNotClickableWebElement(item);
                    item.Click();
                    // driver.FindElement(By.PartialLinkText(link)).Click();
                    #endregion
                }

            }
        }

        public string GetCourseLink(string courseName)
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
            //            // MessageBox.Show(item.Text);
            //            if (item.Text.Equals("Редагувати") || item.Text.Equals("Change"))
            //            {
            //                var link = item.GetAttribute("href");
            //                //item.FindElement(By.LinkText(link)).Click();
            //                //driver.Navigate().GoToUrl(link);
            //                tmpLink = link;

            //            }
            //        }
            //    }
            //}
            return tmpLink;
        }
    }
}

