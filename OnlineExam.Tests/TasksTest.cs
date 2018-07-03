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
    public class TasksTest : BaseTest
    {
        public TasksTest()
        {
        }

        [Fact]
        public void AddNewTaskTest()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);

            var TeacherTasksPage = new SideBar(driver).TasksMenuItemClick();
            var Tasks = new TeacherExerciseManagerPage(driver);
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = new AddTaskAsTeacherPage(driver);
            AddTaskPage.ChooseCourse("C# Essential");
            AddTaskPage.AddTaskNameForNewTask("Proba4");
            //var loginPage = InitPage<LogInPage>();

            //AddTaskPage.AddTestCasesCode("Tratataaa case code blalala");
            //AddTaskPage.AddDescriptionForNewTask("New description tratata blablabla");
            //AddTaskPage.AddBaseCodeForNewTask("yo maaaaaaaaaan");

            AddTaskPage.ClickOnAddButton();
            Assert.True(Tasks.IsTaskAvailable("Proba4"));
        }

        [Fact]
        public void DeleteTask()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = new SideBar(driver).TasksMenuItemClick();
            var Tasks = new TeacherExerciseManagerPage(driver);
            Tasks.ClickOnDeleteButton("Proba4");
            Assert.False(Tasks.IsTaskAvailable("Proba4"));
        }

        [Fact]
        public void IsTaskAvailable()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = new TasksPage(driver);
            Assert.True(ListOfTasks.IsTaskAvailable("Proba3"));
        }

        [Fact]
        public void ClickOnTasksButton()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = new TasksPage(driver);
            var taskRowItem = ListOfTasks.GetByName("Proba1");
            Assert.NotNull(taskRowItem);
            taskRowItem.ClickOnTasksButton();
            Thread.Sleep(3000);
            var title = driver.Title;
            Assert.Equal("Task View - WebApp", title);
        }

        [Fact]
        public void TaskButtonAvailbaleeee()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = new TasksPage(driver);
            var taskRowItem = ListOfTasks.GetByTasksButton("Tasks");
            Assert.NotNull(taskRowItem);
            //taskRowItem.ClickOnTasksButton();
            //Thread.Sleep(3000);
            //var title = driver.Title;
            //Assert.Equal("Task View - WebApp", title);
        }

        [Fact]
        public void ChangeButtonInTeaacherExerciseManager()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var TeacherTasksPage = new SideBar(driver).TasksMenuItemClick();
            var Tasks = new TeacherExerciseManagerPage(driver);
            Tasks.ClickOnChangeButton("PrivetKakdela");
            Thread.Sleep(3000);
        }

        [Fact]
        public void TaskViewTestPAGE()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = new TasksPage(driver);
         //   ListOfTasks.ClickOnTasksButton("PrivetKakdela");
            var TaskView = new TaskViewPage(driver);
            //BasePage.WaitWhileNotClickableWebElement(TaskView).OkButton
            //TaskView.ClickOnOkButton();
            var url = driver.Url;
            Assert.Equal("http://localhost:55842/CourseManagement/ShowExercise/1", url);

            Thread.Sleep(3000);
        }


    }
}
