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
    public class SolutionCodePageTest : BaseTest
    {
        private Header header;
        private SideBar CoursesPage;
        private CourseManagementPage CoursesList;

        public SolutionCodePageTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            string courseName = "C# Starter";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var CoursesPage = ConstructPage<SideBar>().GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    firstBlock.ClickCourseLink();
                }
            }
        }


        [Fact]
        public void TaskExecuting()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                fixture.test = fixture.extentReports.CreateTest("TaskExecuting");
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnExecuteButton();                    
                }
            }
            );
        }


        [Fact]
        public void TaskDone()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                fixture.test = fixture.extentReports.CreateTest("ClickOnDoeneButton");
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnDoneButton();
                }
            }
            );
        }

        [Fact]
        public void ExitButton()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                fixture.test = fixture.extentReports.CreateTest("ClickOnExitButton");
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnExitButton();
                    var url = driver.GetCurrentUrl();
                    Assert.Equal(url, "http://localhost:55842/");
                }
            }
        );

        }


        [Fact]
        public void Compilation()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                fixture.test = fixture.extentReports.CreateTest("IsCompilationTrue?");
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnExecuteButton();
                    Code = ConstructPage<SolutionCodePage>();
                    var result = Code.FieldWithResultOfCompilationCode.Text;
                    Thread.Sleep(3000);
                    Assert.Empty(result);
                }
            }
);

        }



        //    [Fact]
        //    public void Review()
        //    {
        //        UITest(() =>
        //        {
        //            string TaskName = "Simple addition";
        //            fixture.test = fixture.extentReports.CreateTest("IsOnReview?");
        //            var ListOfTasks = ConstructPage<TasksPage>();
        //            var blocks = ListOfTasks.GetBlocks();
        //            if (blocks != null)
        //            {
        //                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
        //                firstblock.ClickOnTasksButton();
        //                var TaskView = ConstructPage<TaskViewPage>();
        //                TaskView.ClickOnStartButton();
        //                var Code = ConstructPage<SolutionCodePage>();
        //                var review = Code.MessageAboutreviewingSolution.Text;
        //                Assert.NotEmpty(review);
        //            }
        //        }
        //);

        //    }








    }
}
