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

        [FindsBy(How = How.XPath, Using = "//a[@href='/EmailMessages']")]
        private IWebElement mailBoxMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/EmailMessages/GetEmail']")]
        private IWebElement contactUsMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/ExerciseManagement']")]
        private IWebElement tasksMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = ".gn-icon-menu")]
        private IWebElement navBarElement;



        /// <summary>
        /// Go to admin panel page by clicking on the adminPanel menu item on side bar
        /// </summary>
        /// <returns>AdminPanelPage</returns>
        public AdminPanelPage GoToAdminPanelPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(adminPanelMenuItemElement);
            adminPanelMenuItemElement.Click();
            return ConstructPage<AdminPanelPage>();
        }

        /// <summary>
        /// Go to teacher news page by clicking on the news menu item on side bar
        /// </summary>
        /// <returns>TeacherNewsPage</returns>
        public TeacherNewsPage GoToTeacherNewsPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(newsMenuItemElement);
            newsMenuItemElement.Click();
            return ConstructPage<TeacherNewsPage>();
        }

        /// <summary>
        /// Go to ratings page by clicking on the rating menu item on side bar
        /// </summary>
        /// <returns>RatingsPage</returns>
        public RatingsPage GoToRatingPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(ratingsMenuItemElement);
            ratingsMenuItemElement.Click();
            return ConstructPage<RatingsPage>();
        }

        /// <summary>
        /// Go to course management page by clicking on courses menu item on side bar
        /// </summary>
        /// <returns>CourseManagementPage</returns>
        public CourseManagementPage GoToCourseManagementPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(coursesMenuItemElement);
            coursesMenuItemElement.Click();
            return ConstructPage<CourseManagementPage>();
        }

        /// <summary>
        /// Go to history favourites page by clicking on code history menu item on side bar
        /// </summary>
        /// <returns>HistoryFavouritePage</returns>
        public HistoryFavouritePage GoToCodeHistoryPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(codeHistoryMenuItemElement);
            codeHistoryMenuItemElement.Click();
            return ConstructPage<HistoryFavouritePage>();
        }

        /// <summary>
        ///  Go to mail box page by clicking on  mail box menu item on side bar
        /// </summary>
        /// <returns>MailBoxPage</returns>
        public MailBoxPage GoToMailBoxPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(mailBoxMenuItemElement);
            mailBoxMenuItemElement.Click();
            return ConstructPage<MailBoxPage>();
        }

        /// <summary>
        /// Go to contact us page by clicking on contact us menu item on side bar
        /// </summary>
        /// <returns>ContactUsPage</returns>
        public ContactUsPage GoToContactUsPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(contactUsMenuItemElement);
            contactUsMenuItemElement.Click();
            return ConstructPage<ContactUsPage>();
        }

        /// <summary>
        /// Go to task page by clicking on task menu item on side bar
        /// </summary>
        /// <returns>TasksPage</returns>
        public TasksPage GoToTasksPage()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(tasksMenuItemElement);
            tasksMenuItemElement.Click();
            return ConstructPage<TasksPage>();
        }
    }
}