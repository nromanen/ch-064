using OnlineExam.Pages.POM;
using System;
using System.Linq;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.Framework.Params;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TasksNTest : BaseNTest
    {

        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;
        private TaskTestParams TaskParams = ParametersResolver.Resolve<TaskTestParams>();


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            var header = ConstructPage<Header>();
           LogProgress("Going to log in page");
            var logInPage = header.GoToLogInPage();
           LogProgress($"Logging in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
           LogProgress("Going to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
           LogProgress("getting list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
               LogProgress($"searching course with {TaskParams.CourseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(TaskParams.CourseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                   LogProgress("Clicking on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }

        [Test]
        public void IsTaskAvailable()
        {
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskParams.TaskName, StringComparison.OrdinalIgnoreCase));
                var ActualName = firstblock.GetName();
                Assert.AreEqual(TaskParams.TaskName, ActualName, "Task with this name isn't available on this page, because of expected task name isn't equal to actual task name");
                var task = new TasksDAL();
                TestContext.Out.WriteLine("\n<br> " + $"Searching task with name '{TaskParams.TaskName}' in database");
                var result = task.IsTaskPresentedByName(TaskParams.TaskName);
                Assert.True(result, $"Task with name '{TaskParams.TaskName}' in't available in database");
            }
        }


        [Test]
        public void ClickOnTasksButton()
        {
            string BaseTitle = "Task View - WebApp";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskParams.TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskParams.TaskName, StringComparison.OrdinalIgnoreCase));
                firstBlock.ClickOnTasksButton();
                var ActualTitle = driver.GetCurrentTitle();
                Assert.AreEqual(BaseTitle, ActualTitle, "\"Tasks\" button doesn't work, because of expected title isn't equal to actual title");
            }

        }


        [Test]
        public void StarsCount()
        {
            string StarsCount = "4";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskParams.TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskParams.TaskName, StringComparison.OrdinalIgnoreCase));
                var count = firstBlock.GetStarsss().ToString();
                Assert.AreEqual(StarsCount, count, "Stars count isn't correct, , because of expected stars cont isn't equal to actual stars count");
            }
        }
    }
}