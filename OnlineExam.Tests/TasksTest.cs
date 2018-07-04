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
    public class TasksTest : BaseTest
    {
        public TasksTest()
        {
        }

        [Fact]
        public void AddNewTaskTest()
        {
            string NEWTASK = "newtask";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);

            var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
            AddTaskPage.ChooseCourse("C# Essential");
            AddTaskPage.AddTaskNameForNewTask(NEWTASK);

            //AddTaskPage.AddTestCasesCode("Tratataaa case code blalala");
            //AddTaskPage.AddDescriptionForNewTask("New description tratata blablabla");
            //AddTaskPage.AddBaseCodeForNewTask("yo maaaaaaaaaan");

            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
            //Assert.True(ListOfTasks.IsTaskAvailable(NEWTASK));
        }

    
        [Fact]
        public void IsTaskAvailable()
        {
            string TaskName = "Proba3";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                Assert.Equal(firstblock.GetName(), TaskName);
            }
            
        }

        [Fact]
        public void ClickOnTasksButton()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = ConstructPage<TasksPage>();
            var taskRowItem = ListOfTasks.GetByName("Proba1");
            Assert.NotNull(taskRowItem);
            taskRowItem.ClickOnTasksButton();
            Thread.Sleep(3000);
            var title = driver.Title;
            Assert.Equal("Task View - WebApp", title);
        }

        [Fact]
        public void ChangeButtonInTeacherExerciseManager()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = ConstructPage<SideBar>().TasksMenuItemClick();
            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
      //      Tasks.ClickOnChangeButton("PrivetKakdela");
            Thread.Sleep(3000);
        }

        [Fact]
        public void TaskViewTestPAGE()
        {
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = ConstructPage<TasksPage>();
            //   ListOfTasks.ClickOnTasksButton("PrivetKakdela");
            var TaskView = ConstructPage<TaskViewPage>();
            //BasePage.WaitWhileNotClickableWebElement(TaskView).OkButton
            //TaskView.ClickOnOkButton();
            var url = driver.Url;
            Assert.Equal("http://localhost:55842/CourseManagement/ShowExercise/1", url);

            Thread.Sleep(3000);
        }
    }
}
