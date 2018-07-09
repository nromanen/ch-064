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
                fixture.test = fixture.extentReports.CreateTest("ChangeLanguageToEnglishTest");
                header.ChangeLanguage(Constants.ENGLISH);
                Assert.Equal(Constants.SIGN_IN_ENGLISH, header.GetSignInButtonText());
                fixture.test.Log(Status.Pass, "Language is changed to english successfully");
                //fixture.test.Pass("Language is changed to english successfully");
            });
        }

        [Fact]
        public void ChangeLanguageToUkraineTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("ChangeLanguageToUkraineTest");
                header.ChangeLanguage(Constants.UKRAINE);
                Assert.Equal(Constants.SIGN_IN_UKRAINE, header.GetSignInButtonText());
                fixture.test.Log(Status.Pass, "Language is changed to ukraine successfully");
                //fixture.test.Pass("Language is changed to ukraine successfully");
            });
        }

        [Fact]
        public void SignInButtonTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("SignInButtonTest");
                var logIn = header.GoToLogInPage();
                Assert.Contains(Constants.LOGIN_URL_CONTAINS, logIn.GetCurrentUrl());
                fixture.test.Log(Status.Pass, "Log in page is visible");
                //fixture.test.Pass("Log in page is visible");
            });
        }

        [Fact]
        public void SignUpButtonTest()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("SignUpButtonTest");
                var regPage = header.GoToRegistrationPage();
                Assert.Contains(Constants.REGISTRATION_URL_CONTAINS, regPage.GetCurrentUrl());
                fixture.test.Log(Status.Pass, "Register page is visible");
                //fixture.test.Pass("Register page is visible");
            });
        }
    }
}