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
        private TasksParams TEMPParamameters = Paramresolver.Resolve<TasksParams>(Constants.PathForJsonParams + "TasksJson.json");

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
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstBlock.TEMP_GetName();
                Assert.AreEqual(TEMPParamameters.TaskName, actualName, "there is any tasks with whis name, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskRecover()
        {
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on Recover Button ");
                myblock.ClickOnRecoverButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.TEMP_GetName();
                Assert.AreEqual(TEMPParamameters.TaskName, actualName, "button \"Recover\" doesn't work, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Click on Delete button");
                myblock.ClickOnDeleteButton();
            }
        }


        [Test]
        public void TaskDelete()
        {
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  name in list of tasks ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on Delete button");
                myblock.ClickOnDeleteButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.Get_DELETED_TaskName();
                Assert.AreEqual(TEMPParamameters.TaskName, actualName, "button \"Delete\" doesn't work, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Click on Recover button");
                myblock.ClickOnRecoverButton();
            }
        }


        [Test]
        public void TaskSolution()
        {
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.TaskName} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TEMPParamameters.TaskName, StringComparison.OrdinalIgnoreCase));
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
            var Tasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "Click on Add button");
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
            TestContext.Out.WriteLine("\n<br> " + $"Chose {TEMPParamameters.CourseName} in drop down list");
            AddTaskPage.ChooseCourse(TEMPParamameters.CourseName);
            TestContext.Out.WriteLine("\n<br> " + $"add '{TEMPParamameters.NewTaskName}' tasks's name for new task");
            AddTaskPage.AddTaskNameForNewTask(TEMPParamameters.NewTaskName);
            TestContext.Out.WriteLine("\n<br> " + "Click on add button");
            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.NewTaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TEMPParamameters.NewTaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstblock.GetName();
                Assert.AreEqual(TEMPParamameters.NewTaskName, actualName, "function \"Add New Task\" doesn't work, because of expected task name isn't equal to actual task name");
            }

            var NewTasks = ConstructPage<TeacherExerciseManagerPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var allblock = NewTasks.GetBlocks();
            if (allblock != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TEMPParamameters.NewTaskName} name in list of tasks  ");
                var firstblock = allblock.FirstOrDefault(x => x.TEMP_GetName().Equals(TEMPParamameters.NewTaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on delete button");
                firstblock.ClickOnDeleteButton();
            }




        }
    }
}