using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Xunit;

namespace OnlineExam.Tests
{
    public class TEMP_Test : BaseTest
    {
        public TEMP_Test() { }

        [Fact]
        public void IsTaskAvailable()
        {
            string TaskName = "Indexers";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            MessageBox.Show("1");
            var taskRowItem = ListOfTasks.GetByName(TaskName);
            MessageBox.Show("2");
            Assert.NotNull(taskRowItem);
        }
    }
}
