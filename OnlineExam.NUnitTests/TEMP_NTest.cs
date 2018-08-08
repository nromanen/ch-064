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
    [Category("Basic")]
    public class TEMP_NTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            sidebar.GoToTasksPage();
        }

        [Test]
        public void IsTaskAvailable()
        {
            string TaskName = "Indexers";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstBlock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstBlock.TEMP_GetName();
                Assert.AreEqual(TaskName, actualName, "there is any tasks with whis name, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskRecover()
        {
            string taskname = "Elevator modeling";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var myblock = blocks.FirstOrDefault(x =>
                    x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                myblock.ClickOnRecoverButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.TEMP_GetName();
                Assert.AreEqual(taskname, actualName, "button \"Recover\" doesn't work, because of expected task name isn't equal to actual task name");
                myblock.ClickOnDeleteButton();
            }
        }


        [Test]
        public void TaskDelete()
        {
            string taskname = "Simple addition";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                myblock.ClickOnDeleteButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var myblock = blocks.FirstOrDefault(x =>
                    x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.Get_DELETED_TaskName();
                Assert.AreEqual(taskname, actualName, "button \"Delete\" doesn't work, because of expected task name isn't equal to actual task name");
                myblock.ClickOnRecoverButton();
            }
        }


        [Test]
        public void TaskSolution()
        {
            string taskname = "Indexers";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                myblock.ClickOnSolutionButton();
            }

            var url = driver.GetCurrentUrl();
            bool f = false;
            if (url.Contains("ExerciseManagement/ExerciseSolutionsIndex/2")) f = true;
            Assert.That(f, "button \"Solution\" doesn't work, because of actual url doesn't contain expected url");
        }


        [Test]
        public void AddNewTaskTest()
        {
            string NEWTASK = "NewTask";

            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
            AddTaskPage.ChooseCourse("C# Essential");
            AddTaskPage.AddTaskNameForNewTask(NEWTASK);
            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                var actualName = firstblock.GetName();
                Assert.AreEqual(NEWTASK, actualName, "function \"Add New Task\" doesn't work, because of expected task name isn't equal to actual task name");
            }

            var NewTasks = ConstructPage<TeacherExerciseManagerPage>();
            var allblock = NewTasks.GetBlocks();
            if (allblock != null)
            {
                var firstblock = allblock.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnDeleteButton();
            }
        }
    }
}