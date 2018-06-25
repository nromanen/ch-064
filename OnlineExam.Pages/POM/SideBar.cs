using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace OnlineExam.Pages.POM
{
    public class SideBar : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = @"a[href*='/AdminPanel/Users']")]
        private IWebElement adminPanelMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/AddNews/News']")]
        private IWebElement newsMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/UserRating']")]
        private IWebElement ratingsMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/CourseManagement']")]
        private IWebElement coursesMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/CodeHistory/History']")]
        private IWebElement codeHistoryMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/EmailMessages']")]
        private IWebElement mailBoxMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/EmailMessages/GetEmail']")]
        private IWebElement contactUsMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = @"a[href*='/ExerciseManagement']")]
        private IWebElement tasksMenuItemElement;

        [FindsBy(How = How.CssSelector, Using = ".gn-icon-menu")]
        private IWebElement navBarElement;


        public SideBar(IWebDriver driver) : base(driver)
        {
        }

        public AdminPanelPage AdminPanelMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(adminPanelMenuItemElement);
            adminPanelMenuItemElement.Click();
            return new AdminPanelPage(driver);
        }
//
        public NewsPage NewsMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(newsMenuItemElement);
            newsMenuItemElement.Click();
            return new NewsPage(driver);
        }

        public RatingsPage RatingsMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(ratingsMenuItemElement);
            ratingsMenuItemElement.Click();
            return new RatingsPage(driver);
        }

        public CoursesPage CoursesMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(coursesMenuItemElement);
            coursesMenuItemElement.Click();
            return new CoursesPage(driver);
        }

        public CodeHistoryPage CodeHistoryMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(codeHistoryMenuItemElement);
            codeHistoryMenuItemElement.Click();
            return new CodeHistoryPage(driver);
        }

        public MailBoxPage MailBoxMenuItemElementClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(mailBoxMenuItemElement);
            mailBoxMenuItemElement.Click();
            return new MailBoxPage(driver);
        }

        public ContactUsPage ContactUsMenuItemElementClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(contactUsMenuItemElement);
            contactUsMenuItemElement.Click();
            return new ContactUsPage(driver);
        }

        public TasksPage TasksMenuItemClick()
        {
            navBarElement.Click();
            WaitWhileNotClickableWebElement(tasksMenuItemElement);
            tasksMenuItemElement.Click();
            return new TaskPage(driver);
        }
    }
}