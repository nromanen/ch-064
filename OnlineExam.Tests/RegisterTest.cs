using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class RegisterTest : BaseTest
    {
        private Header header;
        private SideBar sideBar;

        public RegisterTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();
            header = ConstructPage<Header>();
            sideBar = ConstructPage<SideBar>();
        }

        [Fact]
        public void CheckIfUserIsPresentedInUserListAfterSignUp()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("CheckIfUserIsPresentedInUserListAfterSignUp");
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.EXAMPLE_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.SignOut();
                var logIn = header.GoToLogInPage();
                logIn.SignIn(Constants.ADMIN_EMAIL, Constants.ADMIN_PASSWORD);
                var adminPanelPage = ConstructPage<SideBar>().GoToAdminPanelPage();
                Assert.True(adminPanelPage.IsUserPresentedInUserList(Constants.EXAMPLE_EMAIL));
            });
        }

        [Fact]
        public void SignUpAsUsedEmail()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("SignUpAsUsedEmail");
                var signUp = header.GoToRegistrationPage();
                signUp.Registration(Constants.STUDENT_EMAIL, Constants.EXAMPLE_PASSWORD, Constants.EXAMPLE_PASSWORD);
                header.GoToHomePage();
                Assert.True(header.IsUserEmailPresentedInHeader(Constants.STUDENT_EMAIL));
                fixture.test.Log(Status.Fail, "Didn't sign up as used email.");
            });
        }

        
    }
}
