using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace OnlineExam.NUnitTests
{
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
            logInPage.SignIn(ConstantsN.STUDENT_EMAIL, ConstantsN.STUDENT_PASSWORD);
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
            UITest(() =>
            {
                string TaskName = "Simple addition";
                var ListOfTasks = ConstructPage<TasksPage>();

                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    Assert.AreEqual(firstblock.GetName(), TaskName);
                }
            }
            );

        }


        [Test]
        public void ClickOnTasksButton()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstBlock.ClickOnTasksButton();
                    var title = driver.GetCurrentTitle();
                    Assert.AreEqual("Task View - WebApp", title);
                }
            }
        );
        }


        [Test]
        public void StarsCount()
        {
            UITest(() =>
            {
                string TaskName = "Simple addition";
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    var count = firstBlock.GetStarsss();
                    Assert.AreEqual("0", count.ToString());
                }

            }
    );
        }
    }
}
