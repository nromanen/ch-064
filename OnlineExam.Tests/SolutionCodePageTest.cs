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
    public class SolutionCodePageTest : BaseTest
    {

        public SolutionCodePageTest() { }

        [Fact]
        public void TaskExecuting()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
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
            );
        }


        [Fact]
        public void TaskDone()
        {
            UITest(() =>
            {
                string TaskName = "Proba2";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
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
            );
        }

        [Fact]
        public void ExitButton()
        {
            UITest(() =>
            {
                string TaskName = "Proba2";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
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
                    Code.ClickOnExitButton();
                        //var url = driver.Url;
                        throw new Exception("Rewrite using Page constructor");
                        //Assert.Equal(url, "http://localhost:55842/");
                        Thread.Sleep(2000);
                }
            }
        );

        }


        [Fact]
        public void Review()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
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
                    var review = Code.MessageAboutreviewingSolution.Text;
                    MessageBox.Show(review);
                    Assert.NotEmpty(review);
                }
            }
    );

        }



        [Fact]
        public void Compilation()
        {
            UITest(() =>
            {
                string TaskName = "Proba1";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
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
                    Thread.Sleep(10000);
                    Code = ConstructPage<SolutionCodePage>();
                    var result = Code.FieldWithResultOfCompilationCode.Text;
                    MessageBox.Show(result);
                    Assert.NotEmpty(result);
                }
            }
);

        }








    }
}
