using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using OnlineExam.Framework;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class TasksTest : BaseTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;
      
        public TasksTest(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

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

        [Fact]
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
                string TaskName = "Simple addition";
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstBlock.ClickOnTasksButton();
                    var title = driver.GetCurrentTitle();
                    Assert.Equal("Task View - WebApp", title);
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
                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstBlock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    var count = firstBlock.GetStarsss();
                    Assert.Equal("0" , count.ToString());
                }

            }
    );
        }
    }
}
