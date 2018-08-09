using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Linq;
using System.Threading;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class SolutionCodePageNTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            string courseName = "C# Starter";
            var header = ConstructPage<Header>();
            TestContext.Out.WriteLine("\n<br> " + "Go to log in page");
            var logInPage = header.GoToLogInPage();
            TestContext.Out.WriteLine("\n<br> " + $"Log in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            TestContext.Out.WriteLine("\n<br> " + "Go to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search course with {courseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + "Click on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }


        [Test]
        public void TaskDone()
        {
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on 'tasks' button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'start' button");
                TaskView.ClickOnStartButton();
                var Code = ConstructPage<SolutionCodePage>();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'execute' button");
                Code.ClickOnExecuteButton();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'done' button");
                Code.ClickOnDoneButton();

            }
            var CoursesPage = ConstructPage<SideBar>().GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals("C# Starter", StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + "Click on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
                ListOfTasks = ConstructPage<TasksPage>();
                TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
                blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    TestContext.Out.WriteLine("\n<br> " + "Click on 'tasks' button");
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TestContext.Out.WriteLine("\n<br> " + "Click on 'start' button");
                    TaskView.ClickOnStartButton();
                    var Code = ConstructPage<SolutionCodePage>();
                    var review = Code.MessageAboutreviewingSolution.Text;
                    Assert.IsNotEmpty(review, "Button \"Done\" doesn't work, because of message about reviewing isn't visible on this page");
                }
            }
        }

        [Test]
        public void ExitButton()
        {

            string TaskName = "Simple addition";
            var BaseUrl = BaseSettings.Fields.Url;
            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on 'tasks' button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'start' button");
                TaskView.ClickOnStartButton();
                var Code = ConstructPage<SolutionCodePage>();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'exit' button");
                Code.ClickOnExitButton();
                var actualUrl = driver.GetCurrentUrl().ToString();
                Assert.AreEqual(BaseUrl+"/", actualUrl, "Exit \"button\" doesn't work, because of expected url isn't equal to actual url");
            }
        }
    }
}