using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlineExam.Pages.POM;
using OnlineExam.Tests;

namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class CourseTests: BaseTest
    {
        private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private Header header;
        private LogInPage logInPage;
        private CourseManagementPage adminPanelPage;

        [SetUp]
        public void SetUp()
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            adminPanelPage = ConstructPage<SideBar>().GoToCourseManagementPage();
        }

        [Test]
        public void tmp()
        {
            DatabaseHelper.Helper.BackupDatabase(PATH+@"\MainBackup.bak","Main", @"(LocalDb)\MSSQLLocalDB");
            var courseManagment = ConstructPage<CourseManagementPage>();
            courseManagment.BtnAddCourse.Click();
            var createCourse = ConstructPage<CreateCoursePage>();
            createCourse.FillCourse("tmp","tmp");
            createCourse.BtnOk.Click();
            Thread.Sleep(2000);
            DatabaseHelper.Helper.RestoreDatabase(PATH + @"\MainBackup.bak", "Main", @"(LocalDb)\MSSQLLocalDB");
        }
    }
}
