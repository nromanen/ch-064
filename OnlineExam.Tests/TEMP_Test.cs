using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(firstBlock.TEMP_GetName(), TaskName);
            }
        }

        [Fact]
        public void TaskCreationDate()
        {
        string CreationDate = "23/06/2018";
        var header = ConstructPage<Header>();
        var logInPage = header.GoToLogInPage();
        logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
        var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
        var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {                
                var allblock = blocks.Where(x => x.TEMP_GetCreationDate().Equals(CreationDate, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(allblock.Count(), 3);                
            }
        }

        [Fact]
        public void TaskUpdateDate()
        {
            string UpdateDate = "03/07/2018";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var allblock = blocks.Where(x => x.TEMP_GetCreationDate().Equals(UpdateDate, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(allblock.Count(), 2);
            }
        }


        [Fact]
        public void ClickSolution()
        {
            string TaskName = "Indexers";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetCreationDate().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstBlock.ClickOn();
                Thread.Sleep(5000);
            }
        }


    }
}
