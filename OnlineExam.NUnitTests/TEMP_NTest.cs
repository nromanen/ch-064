using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.DatabaseHelper.DAL;

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
           LogProgress("Go to log in page");
            var logInPage = header.GoToLogInPage();
           LogProgress( $"Log in as teacher: email {Constants.TEACHER_EMAIL}, password {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
           LogProgress("Go to the tasks page");
            sidebar.GoToTasksPage();
        }

        [Test]
        public void IsTaskAvailable()
        {
            string TaskName = "Indexers";
           LogProgress("get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstBlock.TEMP_GetName();
                Assert.AreEqual(TaskName, actualName, "there is any tasks with whis name, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Creating connection with database");
                var task = new TasksDAL();
                TestContext.Out.WriteLine("\n<br> " + $"Searching task with name '{TaskName}' in database");
                var result =task.IsTaskPresentedByName(TaskName);
                Assert.True(result, $"Task with name '{TaskName}' in't available in database");
            }
        }


        [Test]
        public void TaskRecover()
        {
            string taskname = "Elevator modeling";

           LogProgress("get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
               LogProgress("Click on Recover Button ");
                myblock.ClickOnRecoverButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
           LogProgress("get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.TEMP_GetName();
                Assert.AreEqual(taskname, actualName, "button \"Recover\" doesn't work, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskDelete()
        {
            string taskname = "Simple addition";

            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {taskname} name in list of tasks  name in list of tasks ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
               LogProgress("Click on Delete button");
                myblock.ClickOnDeleteButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
           LogProgress("get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.Get_DELETED_TaskName();
                Assert.AreEqual(taskname, actualName, "button \"Delete\" doesn't work, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskSolution()
        {
            string taskname = "Indexers";
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {taskname} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
               LogProgress("click on solution button");
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
            string NewTask = "NewTask";
            string coursename = "C# Essential";

            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
           LogProgress("Click on Add button");
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
           LogProgress($"Chose {coursename} in drop down list");
            AddTaskPage.ChooseCourse(coursename);
           LogProgress($"add '{NEWTASK}' tasks's name for new task");
            AddTaskPage.AddTaskNameForNewTask(NEWTASK);
           LogProgress("Click on add button");
            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {NEWTASK} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                var actualName = firstblock.GetName();
                Assert.AreEqual(NewTask, actualName, "function \"Add New Task\" doesn't work, because of expected task name isn't equal to actual task name");
                var task = new TasksDAL();
                TestContext.Out.WriteLine("\n<br> " + $"Searching task with name '{NewTask}' in database");
                var result = task.IsTaskPresentedByName(NewTask);
                Assert.True(result, $"Task with name '{NewTask}' in't available in database");
            }
        }
    }
}