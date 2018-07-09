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
    [Collection("MyTestCollection")]
    public class TasksTest : BaseTest
    {
        public TasksTest(BaseFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void IsTaskAvailable()
        {
            UITest(() =>
            {
                string TaskName = "Proba3";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                this.driver.GoToUrl("http://localhost:55842/CourseManagement/ShowExercise/1");
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(firstblock.GetName(), TaskName);
                }
            }
            );

        }

        [Fact]
        public void ClickOnTasksButton()
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
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    MessageBox.Show(firstBlock.GetButtonText());
                    firstBlock.ClickOnTasksButton();
                    Thread.Sleep(3000);
                    //var title = driver.Title;
                    //Assert.Equal("Task View - WebApp", title);
                }
            }
        );
        }


        [Fact]
        public void StarsCount()
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
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));

                }

            }
    );
        }
    }
}
