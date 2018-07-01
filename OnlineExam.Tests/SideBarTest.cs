using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    public class SideBarTest : BaseTest
    {
        public SideBarTest()
        {
            BeginTest();
        }

        [Fact]
        public void GoToRatingsPageTest()
        {
            var sideBar = new SideBar(driver);
            var ratingPage = sideBar.GoToRatingPage();
            Assert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetUrl());
        }

        [Fact]
        public void GoToCoursesPageTest()
        {
            var sideBar = new SideBar(driver);
            var coursesPage = sideBar.GoToCourseManagementPage();
            Assert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetUrl());
        }
        [Fact]
        public void GoToContactUsPageTest()
        {
            var sideBar = new SideBar(driver);
            var contactUsPage = sideBar.GoToContactUsPage();
            Assert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetUrl());
        }
    }
}