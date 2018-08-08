using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OnlineExam.Framework;

namespace OnlineExam.NUnitTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class TasksNTest : BaseNTest
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
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            sidebar.GoToCourseManagementPage();

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

        [Test]
        public void IsTaskAvailable()
        {
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();

            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var ActualName = firstblock.GetName();
                Assert.AreEqual(TaskName, ActualName, "Task with this name isn't available on this page, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void ClickOnTasksButton()
        {
            string BaseTitle = "Task View - WebApp";
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstBlock.ClickOnTasksButton();
                var ActualTitle = driver.GetCurrentTitle();
                Assert.AreEqual(BaseTitle, ActualTitle, "\"Tasks\" button doesn't work, because of expected title isn't equal to actual title");
            }

        }


        [Test]
        public void StarsCount()
        {
            string StarsCount = "4";
            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var count = firstBlock.GetStarsss().ToString();
                Assert.AreEqual(StarsCount, count, "Stars count isn't correct, , because of expected stars cont isn't equal to actual stars count");
            }
        }
    }
}