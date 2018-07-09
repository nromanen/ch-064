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
    public class CheckContentUserInfoPage : BaseTest
    {
        public CheckContentUserInfoPage()
        { 
        }

        [Fact]
        public void TestChangeName()
        {
            BeginTest();
            NavigateTo("http://localhost:55842/Account/Login");
            System.Threading.Thread.Sleep(1000);
            var loginPage = ConstructPage<LogInPage>();
            var indexPage = loginPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            var header = ConstructPage<Header>();
            var userInfo = header.GoToUserAccountPage();
                        
            var isOpened = driver.GetCurrentUrl().EndsWith("/User");
            Assert.True(isOpened);

            var userInfoPage = ConstructPage<UserInfoPage>();
            Assert.True(userInfoPage.HasChangePasswordButton());
            Assert.True(userInfoPage.HasChangeNameButton());
            Assert.True(userInfoPage.HasChangeEmailButton());

            var userEmail = userInfoPage.GetEmail();
            var isEqual = String.Equals(userEmail, "student3@gmail.com");
            Assert.True(isEqual);


        }
    }
}
