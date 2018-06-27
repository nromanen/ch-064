using OnlineExam.Pages.POM;
using Xunit;

namespace OnlineExam.Tests
{
    public class AddNewTaskAsTeacher : BaseTest//, IDisposable
    {
        public AddNewTaskAsTeacher()
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
            AddTaskPage.AddTaskNameForNewTask("Proba2");
            AddTaskPage.ClickOnAddButton();
           // Assert.Contains(Tasks.IsTaskAvailable("Proba2"),);
            
        }


        public void Dispose()
        {
            driver.Dispose();
        }

    }
}
