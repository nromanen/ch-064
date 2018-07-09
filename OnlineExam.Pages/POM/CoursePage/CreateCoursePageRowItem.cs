using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM.CoursePage
{
    public class CreateCoursePageRowItem: BasePageElement
    {
        // Created by Roma ༼ つ ◕_◕ ༽つ

        public CreateCoursePageRowItem(){ }

        public CreateCoursePageRowItem(IWebElement searchContext) : base(searchContext){ }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)
        [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement courseName { get; set; }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(2)
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement createDate { get; set; }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1) > a:nth-child(1)
        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1) > a:nth-child(1)
        [FindsBy(How = How.CssSelector, Using = "a:nth-child(1)")]
        public IWebElement link { get; set; }

        public void ClickOnCourseTitle()
        {
            //System.Windows.Forms.MessageBox.Show(courseName.GetAttribute("href").ToString());
            //System.Windows.Forms.MessageBox.Show(courseName.GetAttribute("value").ToString());
           // var tmp = courseName.GetAttribute("href");
            
            
            courseName.Click();
        }

        public string GetCourseName()
        {
            return courseName.Text;
        }

        public string GetCourseCreatingDate()
        {
            return createDate.Text;
        }

        public string GetUrl()
        {
            return courseName.GetAttribute("href");
        }

        public void ClickCourseLink()
        {
            link.Click();
        }
    }
}
