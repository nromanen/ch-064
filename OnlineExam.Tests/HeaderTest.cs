using OnlineExam.Pages.POM;
using RelevantCodes.ExtentReports;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class HeaderTest : BaseTest
    {
        private Header header;

        public HeaderTest(BaseFixture fixture) :base(fixture)
        {
            BeginTest();
            header = ConstructPage<Header>();
        }

        [Fact]
        public void ChangeLanguageToEnglishTest()
        {
            fixture.test = fixture.extent.StartTest("ChangeLanguageToEnglishTest");
            header.ChangeLanguage(Constants.ENGLISH);
            Assert.Equal(Constants.SIGN_IN_ENGLISH, header.GetSignInButtonText());
            fixture.test.Log(LogStatus.Pass, "Language is changed to english successfully");

        }

        [Fact]
        public void ChangeLanguageToUkraineTest()
        {
            fixture.test = fixture.extent.StartTest("ChangeLanguageToUkraineTest");
            header.ChangeLanguage(Constants.UKRAINE);
            Assert.Equal(Constants.SIGN_IN_UKRAINE, header.GetSignInButtonText());
            fixture.test.Log(LogStatus.Pass, "Language is changed to ukraine successfully");
        }

        [Fact]
        public void SignInButtonTest()
        {
            fixture.test = fixture.extent.StartTest("SignInButtonTest");
            var logIn = header.GoToLogInPage();
            Assert.Contains(Constants.LOGIN_URL_CONTAINS, logIn.GetUrl());
            fixture.test.Log(LogStatus.Pass, "Log in page is visible");
        }

        [Fact]
        public void SignUpButtonTest()
        {
            fixture.test = fixture.extent.StartTest("SignUpButtonTest");
            var regPage = header.GoToRegistrationPage();
            Assert.Contains(Constants.REGISTRATION_URL_CONTAINS, regPage.GetUrl());
            fixture.test.Log(LogStatus.Pass, "Register page is visible");
        }

      
    }
}