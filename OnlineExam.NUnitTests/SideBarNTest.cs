using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SideBarNTest : BaseNTest
    {
        private SideBar sideBar;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void GoToRatingsPageTest()
        {
            var ratingPage = sideBar.GoToRatingPage();
            StringAssert.Contains(Constants.RATING_URL_CONTAINS, ratingPage.GetCurrentUrl());
        }

        [Test]
        public void GoToCoursesPageTest()
        {
            var coursesPage = sideBar.GoToCourseManagementPage();
            StringAssert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, coursesPage.GetCurrentUrl());
        }

        [Test]
        public void GoToContactUsPageTest()
        {
            var contactUsPage = sideBar.GoToContactUsPage();
            StringAssert.Contains(Constants.CONTACTUS_URL_CONTAINS, contactUsPage.GetCurrentUrl());
        }
    }
}