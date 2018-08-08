using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Category("Critical")]
    [Category("Basic")]
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
            var currentUrl = ratingPage.GetCurrentUrl();
            StringAssert.Contains(Constants.RATING_URL_CONTAINS, currentUrl,
                $"Current url does not contain {Constants.RATING_URL_CONTAINS}");
        }

        [Test]
        public void GoToCoursesPageTest()
        {
            var coursesPage = sideBar.GoToCourseManagementPage();
            var currentUrl = coursesPage.GetCurrentUrl();
            StringAssert.Contains(Constants.COURSEMANAGEMENT_URL_CONTAINS, currentUrl,
                $"Current url does not contain {Constants.COURSEMANAGEMENT_URL_CONTAINS}");
        }

        [Test]
        public void GoToContactUsPageTest()
        {
            var contactUsPage = sideBar.GoToContactUsPage();
            var currentUrl = contactUsPage.GetCurrentUrl();
            StringAssert.Contains(Constants.CONTACTUS_URL_CONTAINS, currentUrl,
                $"Current url does not contain {Constants.CONTACTUS_URL_CONTAINS}");
        }
    }
}