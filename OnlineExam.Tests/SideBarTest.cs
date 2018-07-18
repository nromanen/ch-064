using AventStack.ExtentReports;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class SideBarTest : BaseTest
    {
        private SideBar sideBar;

        public SideBarTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
            sideBar = ConstructPage<SideBar>();
        }

        //[Fact]
        public void GoToRatingsPageTest()
        {
            UITest(() =>
            {
                var ratingPage = sideBar.GoToRatingPage();
                Assert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetCurrentUrl());
            });
        }

        //[Fact]
        public void GoToCoursesPageTest()
        {
            UITest(() =>
            {
                var coursesPage = sideBar.GoToCourseManagementPage();
                Assert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetCurrentUrl());
            });
        }

        //[Fact]
        public void GoToContactUsPageTest()
        {
            UITest(() =>
            {
                var contactUsPage = sideBar.GoToContactUsPage();
                Assert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetCurrentUrl());
            });
        }
    }
}