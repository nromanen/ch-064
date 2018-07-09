using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class ChangeNameTest : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private UserInfoPage userInfo;


        public ChangeNameTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
        }

        [Fact]
        public void TestChangeName()
        {
            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("TestChangeName");
                //BeginTest();
                //NavigateTo("http://localhost:55842/Account/Login");
                //System.Threading.Thread.Sleep(1000);
                //var loginPage = ConstructPage<LogInPage>();
                //var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
                //var header = ConstructPage<Header>();
                var userInfo = header.GoToUserAccountPage();
                var changeNamePage = userInfo.OpenChangeNamePage();

                changeNamePage.SetNewName("teacher@gmail.com", Constants.TEACHER_PASSWORD);
                //header = ConstructPage<Header>();
                var newUserName = header.GetHeaderUserName();
                var isEqual = String.Equals(Constants.TEACHER_EMAIL, newUserName, StringComparison.InvariantCultureIgnoreCase);
                Assert.True(isEqual);
                fixture.test.Log(Status.Pass, "Name is changed");
            });
        }
    }
    
}
