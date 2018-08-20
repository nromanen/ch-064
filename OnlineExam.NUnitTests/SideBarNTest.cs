using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;
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

        private SideBarTestParams sideBarTestParams;


        [SetUp]
        public override void SetUp()
        {
            sideBarTestParams =
                ParametersResolver.Resolve<SideBarTestParams>();
            base.SetUp();
            sideBar = ConstructPage<SideBar>();
        }

        [Test]
        public void GoToRatingsPageTest()
        {
            var ratingPage = sideBar.GoToRatingPage();
            var currentUrl = ratingPage.GetCurrentUrl();
            StringAssert.Contains(sideBarTestParams.RatingUrlContains, currentUrl,
                $"Current url does not contain {sideBarTestParams.RatingUrlContains}");
        }

        [Test]
        public void GoToCoursesPageTest()
        {
            var coursesPage = sideBar.GoToCourseManagementPage();
            var currentUrl = coursesPage.GetCurrentUrl();
            StringAssert.Contains(sideBarTestParams.CourseManagementUrlContains, currentUrl,
                $"Current url does not contain {sideBarTestParams.CourseManagementUrlContains}");
        }

        [Test]
        public void GoToContactUsPageTest()
        {
            var contactUsPage = sideBar.GoToContactUsPage();
            var currentUrl = contactUsPage.GetCurrentUrl();
            StringAssert.Contains(sideBarTestParams.ContactUsUrlContains, currentUrl,
                $"Current url does not contain {sideBarTestParams.ContactUsUrlContains}");
        }
    }
}