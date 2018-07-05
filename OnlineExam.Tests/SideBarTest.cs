using OnlineExam.Pages.POM;
using RelevantCodes.ExtentReports;
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
            fixture.test = fixture.extent.StartTest("GoToRatingsPageTest");
            var ratingPage = sideBar.GoToRatingPage();
            Assert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetUrl());
            fixture.test.Log(LogStatus.Pass,"Rating page is presented");
        }

        [Fact]
        public void GoToCoursesPageTest()
        {
            fixture.test = fixture.extent.StartTest("GoToCoursesPageTest");
            var coursesPage = sideBar.GoToCourseManagementPage();
            Assert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetUrl());
            fixture.test.Log(LogStatus.Pass, "Courses page is presented");

        }

        [Fact]
        public void GoToContactUsPageTest()
        {
            fixture.test = fixture.extent.StartTest("GoToContactUsPageTest");
            var contactUsPage = sideBar.GoToContactUsPage();
            Assert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetUrl());
            fixture.test.Log(LogStatus.Pass, "Contact us page is presented");

        }

       
    }
}