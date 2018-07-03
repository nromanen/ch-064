using OnlineExam.Pages.POM;
using System;
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
            
            //AddTaskPage.AddTestCasesCode("Tratataaa case code blalala");
            //AddTaskPage.AddDescriptionForNewTask("New description tratata blablabla");

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
        public void Probuem()
        {
            var header = new Header(driver);
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
        }
    }
}
