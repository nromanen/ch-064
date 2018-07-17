using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;


namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Fixtures)]
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
            Assert.AreEqual(Constants.SIGN_IN_ENGLISH, header.GetSignInButtonText());
        }

        [Test]
        public void ChangeLanguageToUkraineTest()
        {
            header.ChangeLanguage(Constants.UKRAINE);
            Assert.AreEqual(Constants.SIGN_IN_UKRAINE, header.GetSignInButtonText());
        }

        [Test]
        public void SignInButtonTest()
        {
            var logIn = header.GoToLogInPage();
            StringAssert.Contains(Constants.LOGIN_URL_CONTAINS, logIn.GetCurrentUrl());
        }

        [Test]
        public void SignUpButtonTest()
        {
            var regPage = header.GoToRegistrationPage();
            StringAssert.Contains(Constants.REGISTRATION_URL_CONTAINS, regPage.GetCurrentUrl());
        }
    }
}