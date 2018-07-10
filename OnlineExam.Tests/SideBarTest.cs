using AventStack.ExtentReports;
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

        [Fact]
        public void GoToRatingsPageTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("GoToRatingsPageTest");
                var ratingPage = sideBar.GoToRatingPage();
                Assert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetCurrentUrl());
                fixture.test.Log(Status.Pass, "Rating page is presented");
            });
        }

        [Fact]
        public void GoToCoursesPageTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("GoToCoursesPageTest");
                var coursesPage = sideBar.GoToCourseManagementPage();
                Assert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetCurrentUrl());
                fixture.test.Log(Status.Pass, "Courses page is presented");
            });
        }

        [Fact]
        public void GoToContactUsPageTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("GoToContactUsPageTest");
                var contactUsPage = sideBar.GoToContactUsPage();
                Assert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetCurrentUrl());
                fixture.test.Log(Status.Pass, "Contact us page is presented");
            });
        }
    }
}