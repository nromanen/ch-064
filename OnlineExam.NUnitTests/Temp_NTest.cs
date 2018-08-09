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
            TestContext.Out.WriteLine("\n<br> " + "Go to log in page");
            var logInPage = header.GoToLogInPage();
            TestContext.Out.WriteLine("\n<br> " +  $"Log in as teacher: email {Constants.TEACHER_EMAIL}, password {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            TestContext.Out.WriteLine("\n<br> " + "Go to the tasks page");
            sidebar.GoToTasksPage();
        }

        [Test]
        public void IsTaskAvailable()
        {
            string TaskName = "Indexers";
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstBlock.TEMP_GetName();
                Assert.AreEqual(TaskName, actualName, "there is any tasks with whis name, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskRecover()
        {
            string taskname = "Elevator modeling";

            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on Recover Button ");
                myblock.ClickOnRecoverButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.TEMP_GetName();
                Assert.AreEqual(taskname, actualName, "button \"Recover\" doesn't work, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Click on Delete button");
                myblock.ClickOnDeleteButton();
            }
        }


        [Test]
        public void TaskDelete()
        {
            string taskname = "Simple addition";

            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {taskname} name in list of tasks  name in list of tasks ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on Delete button");
                myblock.ClickOnDeleteButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.Get_DELETED_TaskName();
                Assert.AreEqual(taskname, actualName, "button \"Delete\" doesn't work, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Click on Recover button");
                myblock.ClickOnRecoverButton();
            }
        }


        [Test]
        public void TaskSolution()
        {
            string taskname = "Indexers";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "click on solution button");
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
            string coursename = "C# Essential";

            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "Click on Add button");
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
            TestContext.Out.WriteLine("\n<br> " + $"Chose {coursename} in drop down list");
            AddTaskPage.ChooseCourse(coursename);
            TestContext.Out.WriteLine("\n<br> " + $"add '{NEWTASK}' tasks's name for new task");
            AddTaskPage.AddTaskNameForNewTask(NEWTASK);
            TestContext.Out.WriteLine("\n<br> " + "Click on add button");
            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {NEWTASK} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                var actualName = firstblock.GetName();
                Assert.AreEqual(NEWTASK, actualName, "function \"Add New Task\" doesn't work, because of expected task name isn't equal to actual task name");
            }

            var NewTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var allblock = NewTasks.GetBlocks();
            if (allblock != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {NEWTASK} name in list of tasks  ");
                var firstblock = allblock.FirstOrDefault(x => x.TEMP_GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on delete button");
                firstblock.ClickOnDeleteButton();
            }
        }
    }
}