using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    public class SaveExecutedTaskToCodeHistoryTest : BaseTest
    {
        public SaveExecutedTaskToCodeHistoryTest()
        {
        }

        [Fact]
        public void TestSaveExecutedTestToCodeHistory()
        {
            string TaskName = "Simple addition";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            NavigateTo("http://localhost:55842/CourseManagement/ShowExercise/1");
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
    }
}
