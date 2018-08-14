using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TestSaveExecutedTestToCodeHistoryN : BaseNTest
    {
        private Header header;
        private LogInPage logInPage;
        private SideBar sideBar;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            header = ConstructPage<Header>();
        }

        [Test]
        public void SaveExecutedTestToCodeHistory()
        {
            LogProgress($"User logging with e-mail: student3@gmail.com and password : {Constants.STUDENT_PASSWORD}");
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            LogProgress("Opening Course managment page");
            sideBar = ConstructPage<SideBar>();
            var courseManagment = sideBar.GoToCourseManagementPage();
            var coursesBlocks = courseManagment.GetBlocks();
            var courseItem = coursesBlocks.FirstOrDefault(x =>
                x.GetCourseName().Equals("C# Essential", StringComparison.OrdinalIgnoreCase));
            courseItem.ClickCourseLink();
            LogProgress("Opening Tasks page");
            var ListOfTasks = ConstructPage<TasksPage>();
            string TaskName = "Indexers";
            string nameOfExecutedTask = "";

            LogProgress("Getting block with task");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock =
                    blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                nameOfExecutedTask = firstblock.GetName();
                firstblock.ClickOnTasksButton();

                var TaskView = ConstructPage<TaskViewPage>();
                TaskView.ClickOnStartButton();

                var Code = ConstructPage<SolutionCodePage>();

                Code.ClickOnExecuteButton();
            }
            LogProgress("Opening History page");
            var historyPage = sideBar.GoToCodeHistoryPage();
            LogProgress("Finding executed task");
            var blocksHistory = historyPage.GetHistoryBlocks();

            bool blockOfExecutedCode = false;

            foreach (var block in blocksHistory)
            {
                if (block.GetTitle() == nameOfExecutedTask)
                {
                    blockOfExecutedCode = true;
                    break;
                }
            }

            Assert.True(blockOfExecutedCode);
        }
    }
}