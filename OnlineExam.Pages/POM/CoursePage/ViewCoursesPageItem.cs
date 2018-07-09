using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Pages.POM.CoursePage
{
    public class ViewCoursesPageItem : BasePageElement
    {
        // Created by Roma ༼ つ ◕_◕ ༽つ

        public ViewCoursesPageItem() { }

        public ViewCoursesPageItem(IWebElement searchContext) : base(searchContext) { }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(1)
        [FindsBy(How = How.CssSelector, Using = ":nth-child(1)")]
        public IWebElement courseName { get; set; }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(2)
        [FindsBy(How = How.CssSelector, Using = ":nth-child(2)")]
        public IWebElement createDate { get; set; }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(3) > form:nth-child(1) > a:nth-child(1)
        [FindsBy(How = How.CssSelector, Using = "a:nth-child(1)")]
        public IWebElement BtnChange { get; set; }

        //.table > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(3) > form:nth-child(1) > a:nth-child(2)
        [FindsBy(How = How.CssSelector, Using = "a:nth-child(2)")]
        public IWebElement BtnDelete { get; set; }

        //.btn-primary
        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        public IWebElement BtnRecover{ get; set; }

        public string GetCourseName()
        {
            return courseName.Text;
        }

        public string GetCourseCreatingDate()
        {
            return createDate.Text;
        }

        public string GetBtnChangeText()
        {
            return BtnChange.Text;
        }

        public string GetBtnDeleteText()
        {
            return BtnDelete.Text;
        }

        public string GetBtnRecoverText()
        {
            return BtnRecover.Text;
        }

        public void ClickBtnChange()
        {
            BtnChange.Click();
        }

        public void ClickBtnDelete()
        {
            BtnDelete.Click();
        }

        public void ClickBtnRecover()
        {
            BtnRecover.Click();
        }
    }
}
