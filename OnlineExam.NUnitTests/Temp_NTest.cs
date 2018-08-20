using OnlineExam.Pages.POM;
using System;
using System.Linq;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Framework.Params;
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
        private TEMP_Params TEMPParams;


        [SetUp]
        public override void SetUp()
        {

            base.SetUp();
            TEMPParams = ParametersResolver.Resolve<TEMP_Params>();
            var header = ConstructPage<Header>();
            LogProgress("Going to log in page");
            var logInPage = header.GoToLogInPage();
            LogProgress(
                $"Logging in as teacher: email {Constants.TEACHER_EMAIL}, password {Constants.TEACHER_PASSWORD}");
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            LogProgress("Going to the tasks page");
            sidebar.GoToTasksPage();
        }

        [Test]
        public void IsTaskAvailable()
        {
            LogProgress("getting list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.TaskName1} name in list of tasks  ");
                var firstBlock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(TEMPParams.TaskName1, StringComparison.OrdinalIgnoreCase));
                var actualName = firstBlock.TEMP_GetName();
                Assert.AreEqual(TEMPParams.TaskName1, actualName,
                    "there is any tasks with whis name, because of expected task name isn't equal to actual task name");
                TestContext.Out.WriteLine("\n<br> " + "Creating connection with database");
                var task = new TasksDAL();
                TestContext.Out.WriteLine("\n<br> " + $"Searching task with name '{TEMPParams.TaskName1}' in database");
                var result = task.IsTaskPresentedByName(TEMPParams.TaskName1);
                Assert.True(result, $"Task with name '{TEMPParams.TaskName1}' in't available in database");
            }
        }


        [Test]
        public void TaskRecover()
        {
            LogProgress("getting list of tasks");
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.TaskName2} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x =>
                    x.Get_DELETED_TaskName().Equals(TEMPParams.TaskName2, StringComparison.OrdinalIgnoreCase));
                LogProgress("Clicking on Recover Button ");
                myblock.ClickOnRecoverButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            LogProgress("getting list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.TaskName2} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(TEMPParams.TaskName2, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.TEMP_GetName();
                Assert.AreEqual(TEMPParams.TaskName2, actualName,
                    "button \"Recover\" doesn't work, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskDelete()
        {
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress(
                    $"searching task with {TEMPParams.TaskName3} name in list of tasks  name in list of tasks ");
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(TEMPParams.TaskName3, StringComparison.OrdinalIgnoreCase));
                LogProgress("Clicking on Delete button");
                myblock.ClickOnDeleteButton();
            }

            ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            LogProgress("getting list of tasks");
            blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.TaskName3} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x =>
                    x.Get_DELETED_TaskName().Equals(TEMPParams.TaskName3, StringComparison.OrdinalIgnoreCase));
                var actualName = myblock.Get_DELETED_TaskName();
                Assert.AreEqual(TEMPParams.TaskName3, actualName,
                    "button \"Delete\" doesn't work, because of expected task name isn't equal to actual task name");
            }
        }


        [Test]
        public void TaskSolution()
        {
            var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
            LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.TaskName1} name in list of tasks  ");
                var myblock = blocks.FirstOrDefault(x =>
                    x.TEMP_GetName().Equals(TEMPParams.TaskName1, StringComparison.OrdinalIgnoreCase));
                LogProgress("clicking on solution button");
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
            LogProgress("Clicking on Add button");
            Tasks.ClickOnAddTaskbutton();
            var AddTaskPage = ConstructPage<AddTaskAsTeacherPage>();
            LogProgress($"Chosing {TEMPParams.CourseName} in drop down list");
            AddTaskPage.ChooseCourse(TEMPParams.CourseName);
            LogProgress($"adding '{TEMPParams.CourseName}' tasks's name for new task");
            AddTaskPage.AddTaskNameForNewTask(TEMPParams.NewTaskName);
            LogProgress("Clicking on add button");
            AddTaskPage.ClickOnAddButton();
            var ListOfTasks = ConstructPage<TasksPage>();
            LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                LogProgress($"searching task with {TEMPParams.NewTaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(TEMPParams.NewTaskName, StringComparison.OrdinalIgnoreCase));
                var actualName = firstblock.GetName();
                Assert.AreEqual(TEMPParams.NewTaskName, actualName,
                    "function \"Add New Task\" doesn't work, because of expected task name isn't equal to actual task name");
                var task = new TasksDAL();
                TestContext.Out.WriteLine(
                    "\n<br> " + $"Searching task with name '{TEMPParams.NewTaskName}' in database");
                var result = task.IsTaskPresentedByName(TEMPParams.NewTaskName);
                Assert.True(result, $"Task with name '{TEMPParams.NewTaskName}' in't available in database");
            }
        }
    }
}