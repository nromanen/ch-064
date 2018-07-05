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
    public class TaskViewPageTest: BaseTest
    {

        public TaskViewPageTest() { }

        [Fact]
        public void TaskExecuting()
        {
            string TaskName = "Simple addition";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                Thread.Sleep(2000);
                var TaskView = ConstructPage<TaskViewPage>();
                TaskView.ClickOnStartButton();
                Thread.Sleep(2000);
                var Code = ConstructPage<SolutionCodePage>();
                Code.ClickOnExecuteButton();
                Thread.Sleep(2000);
            }
        }


        [Fact]
        public void TaskDone()
        {
            string TaskName = "Proba2";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            driver.Navigate().GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                Thread.Sleep(2000);
                var TaskView = ConstructPage<TaskViewPage>();
                TaskView.ClickOnStartButton();
                Thread.Sleep(2000);
                var Code = ConstructPage<SolutionCodePage>();
                Code.ClickOnDoneButton();
                Thread.Sleep(2000);
            }
        }


    }
}
