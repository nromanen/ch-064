using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [Category("Critical")]
    [Category("Basic")]
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class HeaderTest : BaseNTest
    {
        private Header header;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            header = ConstructPage<Header>();
        }

        [Test]
        public void ChangeLanguageToEnglishTest()
        {
            header.ChangeLanguage(Constants.ENGLISH);
            var signInButtonText = header.GetSignInButtonText();
            Assert.AreEqual(resxManager.GetString("signIn"), signInButtonText, "Sign In button has another text" +
                                                                               "Language does not changed");
        }

        [Test]
        public void ChangeLanguageToUkraineTest()
        {
            header.ChangeLanguage(Constants.UKRAINE);
            resxManager = header.GetCurrentLanguage();
            var signInButtonText = header.GetSignInButtonText();
            Assert.AreEqual(resxManager.GetString("signIn"), signInButtonText, "Sign In button has another text" +
                                                                               "Language does not changed");
        }

        [Test]
        public void SignInButtonTest()
        {
            var logIn = header.GoToLogInPage();
            var currentUrl = logIn.GetCurrentUrl();
            StringAssert.Contains(Constants.LOGIN_URL_CONTAINS, currentUrl, $"Current url does not contain {Constants.LOGIN_URL_CONTAINS}");
        }

        [Test]
        public void SignUpButtonTest()
        {
            var regPage = header.GoToRegistrationPage();
            var currentUrl = regPage.GetCurrentUrl();
            StringAssert.Contains(Constants.REGISTRATION_URL_CONTAINS, currentUrl, $"Current url does not contain {Constants.REGISTRATION_URL_CONTAINS}");
        }
    }
}