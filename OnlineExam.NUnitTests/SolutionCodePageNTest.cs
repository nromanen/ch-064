using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Linq;
using System.Threading;
using OnlineExam.Framework.Params;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SolutionCodePageNTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;
        private SolutionCodePageParams SolCodeParams;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            SolCodeParams = ParametersResolver.Resolve<SolutionCodePageParams>();

            var header = ConstructPage<Header>();
            LogProgress("Going to log in page");
            var logInPage = header.GoToLogInPage();
            LogProgress(
                $"Logging in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            LogProgress("Going to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            LogProgress("getting list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                LogProgress($"searching course with {SolCodeParams.CourseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x =>
                    x.GetCourseName().Equals(SolCodeParams.CourseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    LogProgress("Clicking on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }


        [Test]
        public void TaskDone()
        {
            var ListOfTasks = ConstructPage<TasksPage>();
            LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(SolCodeParams.TaskName, StringComparison.OrdinalIgnoreCase));
                LogProgress("Clicking on 'tasks' button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                LogProgress("Clicking on 'start' button");
                TaskView.ClickOnStartButton();
                var Code = ConstructPage<SolutionCodePage>();
                LogProgress("Clicking on 'execute' button");
                Code.ClickOnExecuteButton();
                LogProgress("Clicking on 'done' button");
                Code.ClickOnDoneButton();
            }

            var CoursesPage = ConstructPage<SideBar>().GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            LogProgress("getting list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x =>
                    x.GetCourseName().Equals("C# Starter", StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    LogProgress("Clicking on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }

                ListOfTasks = ConstructPage<TasksPage>();
                LogProgress("getting list of tasks");
                blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    LogProgress($"searching task with {SolCodeParams.TaskName} name in list of tasks  ");
                    var firstblock = blocks.FirstOrDefault(x =>
                        x.GetName().Equals(SolCodeParams.TaskName, StringComparison.OrdinalIgnoreCase));
                    LogProgress("Clicking on 'tasks' button");
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    LogProgress("Clicking on 'start' button");
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    var review = Code.MessageAboutreviewingSolution.Text;
                    Assert.IsNotEmpty(review,
                        "Button \"Done\" doesn't work, because of message about reviewing isn't visible on this page");
                }
            }
        }

        [Test]
        public void ExitButton()
        {
            var BaseUrl = BaseSettings.Fields.Url;
            var ListOfTasks = ConstructPage<TasksPage>();
            LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {SolCodeParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(SolCodeParams.TaskName, StringComparison.OrdinalIgnoreCase));
                LogProgress("Clicking on 'tasks' button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                LogProgress("Clicking on 'start' button");
                TaskView.ClickOnStartButton();
                var Code = ConstructPage<SolutionCodePage>();
                LogProgress("Clicking on 'exit' button");
                Code.ClickOnExitButton();
                var actualUrl = driver.GetCurrentUrl().ToString();
                Assert.AreEqual(BaseUrl + "/", actualUrl,
                    "Exit \"button\" doesn't work, because of expected url isn't equal to actual url");
            }
        }
    }
}