using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Pages.POM;
using Xunit;
using static OnlineExam.Tests.Properties.Settings;

namespace OnlineExam.Tests
{
    public class NewsTest : BaseTest, IDisposable
    {
        public NewsTest()
        {
        }

        [Fact]
        public void CreateNewsTest()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Default.TEACHER_EMAIL, Default.TEACHER_PASSWORD);
            var teacherNewsPage = new SideBar(driver).NewsMenuItemClick();
            teacherNewsPage.CreateArticle();
            Assert.True(teacherNewsPage.IsNewsPresentedInNewsList("Title")) ;
            
        }


        public void Dispose()
        {
            driver.Dispose();
        }
    }
    
}
