using NUnit.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class HeaderTest : BaseTest
    {
        private Header header;

    

        [SetUp]
        public void SetUp()
        {
            BeginTest();
            header = ConstructPage<Header>();
        }

        [Test]
        public void ChangeLanguageToEnglishTest()
        {
            UITest(() =>
            {
                header.ChangeLanguage(Constants.ENGLISH);
                Assert.AreEqual(Constants.SIGN_IN_ENGLISH, header.GetSignInButtonText());
            });
        }

        [Test]
        public void ChangeLanguageToUkraineTest()
        {
            UITest(() =>
            {
                header.ChangeLanguage(Constants.UKRAINE);
                Assert.AreEqual(Constants.SIGN_IN_UKRAINE, header.GetSignInButtonText());
            });
        }

        [Test]
        public void SignInButtonTest()
        {
            UITest(() =>
            {
                var logIn = header.GoToLogInPage();
                StringAssert.Contains(Constants.LOGIN_URL_CONTAINS, logIn.GetCurrentUrl());
            });
        }

        [Test]
        public void SignUpButtonTest()
        {
            UITest(() =>
            {
                var regPage = header.GoToRegistrationPage();
                StringAssert.Contains(Constants.REGISTRATION_URL_CONTAINS, regPage.GetCurrentUrl());
            });
        }
    }
}