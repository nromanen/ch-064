﻿using OnlineExam.Pages.POM.CoursePage;
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
        #region trash
        /* public void DeleteCourse(string courseName)
         {
             var List = FindCourse(courseName);
             foreach (var item in List)
             {
                 //MessageBox.Show(item.Text);
                 if (item.Text.Equals("Видалити") || item.Text.Equals("Delete"))
                     item.Click();
             }

         }*/

        /*public bool IsCourseDeleted(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                //MessageBox.Show(item.Text);
                if (item.Text.Equals("Відновити") || item.Text.Equals("Recover"))
                    return true;
            }
            return false;
        }*/

        /*public void RestoreCourse(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                if (item.Text.Equals("Відновити") || item.Text.Equals("Recover"))
                    item.Click();
            }
        }*/

        /*public bool IsCourseRestored(string courseName)
        {
            var List = FindCourse(courseName);
            foreach (var item in List)
            {
                //MessageBox.Show(item.Text);
                if (item.Text.Equals("Видалити") || item.Text.Equals("Delete"))
                    return true;
            }
            return false;
        }*/

        /*public IList<IWebElement> FindCourse(string courseName)
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
        }*/


        /*public string GetCourseLink(string courseName)
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
        }*/
        #endregion


    }
}

