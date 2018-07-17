using NUnit.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class SideBarTest : BaseTest
    {
        private SideBar sideBar;


        [SetUp]
        public void SetUp()
        {
            BeginTest();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void GoToRatingsPageTest()
        {
            UITest(() =>
            {
                var ratingPage = sideBar.GoToRatingPage();
     //           Assert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetCurrentUrl());
            });
        }

        [Test]
        public void GoToCoursesPageTest()
        {
            UITest(() =>
            {
                var coursesPage = sideBar.GoToCourseManagementPage();
   //             Assert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetCurrentUrl());
            });
        }

        [Test]
        public void GoToContactUsPageTest()
        {
            UITest(() =>
            {
                var contactUsPage = sideBar.GoToContactUsPage();
          //      Assert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetCurrentUrl());
            });
        }
    }
}