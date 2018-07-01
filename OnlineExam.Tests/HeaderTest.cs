using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    public class HeaderTest : BaseTest

    {
        public HeaderTest()
        {
            BeginTest();
        }

        [Fact]
        public void ChangeLanguageToEnglishTest()
        {
            var header = new Header(driver);
            header.ChangeLanguage(Constants.ENGLISH);
            Assert.Equal(Constants.SIGN_IN_ENGLISH,header.GetSignInButtonText());
        }

        [Fact]
        public void ChangeLanguageToUkraineTest()
        {
            var header = new Header(driver);
            header.ChangeLanguage(Constants.UKRAINE);
            Assert.Equal(Constants.SIGN_IN_UKRAINE,header.GetSignInButtonText());
        }

        [Fact]
        public void SignInButtonTest()
        {
            var header = new Header(driver);
            var logIn = header.GoToLogInPage();
            Assert.Contains(Constants.LOGIN_URL_CONTAINS,logIn.GetUrl());
        }

        [Fact]
        public void SignUpButtonTest()
        {
            var header = new Header(driver);
            var regPage = header.GoToRegistrationPage();
            Assert.Contains(Constants.REGISTRATION_URL_CONTAINS,regPage.GetUrl());
        }

    }
}
