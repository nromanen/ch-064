using System;
using System.Collections.Generic;
using System.Linq;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
    public class SideBar : BasePage
    {
        public SideBar()
        {
        }
        [FindsBy(How = How.XPath, Using = "//a[@href='/AdminPanel/Users']")]
        private IWebElement adminPanelMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = "a[href*='/AddNews/News']")]
        private IWebElement newsMenuItemElement;

        [FindsBy(How = How.XPath, Using = "//a[@href='/UserRating']")]
        private IWebElement ratingsMenuItemElement;

        [FindsBy(How = How.XPath, Using = "//a[@href='/CourseManagement']")]
        private IWebElement coursesMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/CodeHistory/History']")]
        private IWebElement codeHistoryMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = "//a[@href='/EmailMessages']")]
        private IWebElement mailBoxMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/EmailMessages/GetEmail']")]
        private IWebElement contactUsMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/ExerciseManagement']")]
        private IWebElement tasksMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = ".gn-icon-menu")]
        private IWebElement navBarElement;




        public AdminPanelPage GoToAdminPanelPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(adminPanelMenuItemElement);
            adminPanelMenuItemElement.Click();
            return ConstructPage<AdminPanelPage>();
        }

        public TeacherNewsPage GoToTeacherNewsPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(newsMenuItemElement);
            newsMenuItemElement.Click();
            return ConstructPage<TeacherNewsPage>();
        }

        public RatingsPage GoToRatingPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(ratingsMenuItemElement);
            ratingsMenuItemElement.Click();
            return ConstructPage<RatingsPage>();
        }

        public CourseManagementPage GoToCourseManagementPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(coursesMenuItemElement);
            coursesMenuItemElement.Click();
            return ConstructPage<CourseManagementPage>();
        }

        public HistoryFavouritePage GoToCodeHistoryPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(codeHistoryMenuItemElement);
            codeHistoryMenuItemElement.Click();
            return ConstructPage<HistoryFavouritePage>();
        }

        public MailBoxPage GoToMailBoxPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(mailBoxMenuItemElement);
            mailBoxMenuItemElement.Click();
            return ConstructPage<MailBoxPage>();
        }

        public ContactUsPage GoToContactUsPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(contactUsMenuItemElement);
            contactUsMenuItemElement.Click();
            return ConstructPage<ContactUsPage>();
        }

        public TasksPage GoToTasksPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(tasksMenuItemElement);
            tasksMenuItemElement.Click();
            return ConstructPage<TasksPage>();
        }
    }
}