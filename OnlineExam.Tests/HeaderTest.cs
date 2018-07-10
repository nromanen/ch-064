using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using Xunit;
using Xunit.Abstractions;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class HeaderTest : BaseTest
    {
        private Header header;

        public HeaderTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
            header = ConstructPage<Header>();
        }

        [Fact]
        public void ChangeLanguageToEnglishTest()
        {
            UITest(() =>
            {
                header.ChangeLanguage(Constants.ENGLISH);
                Assert.Equal(Constants.SIGN_IN_ENGLISH, header.GetSignInButtonText());
            });
        }

        [Fact]
        public void ChangeLanguageToUkraineTest()
        {
            UITest(() =>
            {
                header.ChangeLanguage(Constants.UKRAINE);
                Assert.Equal(Constants.SIGN_IN_UKRAINE, header.GetSignInButtonText());
            });
        }

        [Fact]
        public void SignInButtonTest()
        {
            UITest(() =>
            {
                var logIn = header.GoToLogInPage();
                Assert.Contains(Constants.LOGIN_URL_CONTAINS, logIn.GetCurrentUrl());
            });
        }

        [Fact]
        public void SignUpButtonTest()
        {
            UITest(() =>
            {
                var regPage = header.GoToRegistrationPage();
                Assert.Contains(Constants.REGISTRATION_URL_CONTAINS, regPage.GetCurrentUrl());
            });
        }
    }
}