using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;
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

        private HeaderTestParams headerTestParams;


        [SetUp]
        public override void SetUp()
        {
        
            base.SetUp();
            headerTestParams =
                ParametersResolver.Resolve<HeaderTestParams>();
            header = ConstructPage<Header>();
        }

        [Test]
        public void ChangeLanguageToEnglishTest()
        {
            header.ChangeLanguage(headerTestParams.English);
            var signInButtonText = header.GetSignInButtonText();
            Assert.AreEqual(resxManager.GetString("signIn"), signInButtonText, "Sign In button has another text" +
                                                                               "Language does not changed");
        }

        [Test]
        public void ChangeLanguageToUkraineTest()
        {
            header.ChangeLanguage(headerTestParams.Ukraine);
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
            StringAssert.Contains(headerTestParams.LoginUrlContains, currentUrl,
                $"Current url does not contain {headerTestParams.LoginUrlContains}");
        }

        [Test]
        public void SignUpButtonTest()
        {
            var regPage = header.GoToRegistrationPage();
            var currentUrl = regPage.GetCurrentUrl();
            StringAssert.Contains(headerTestParams.RegistrationUrlContains, currentUrl,
                $"Current url does not contain {headerTestParams.RegistrationUrlContains}");
        }
    }
}