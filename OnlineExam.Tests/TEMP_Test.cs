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
    public class TEMP_Test : BaseTest
    {

        private Header header;
        private SideBar sidebar;


        public TEMP_Test(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            sidebar.GoToTasksPage();
        }

        //[Fact]
        public void IsTaskAvailable()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstBlock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(firstBlock.TEMP_GetName(), TaskName);
                }
            }
            );
        }



        //[Fact]
        public void TaskRecover()
        {
            UITest(() =>
            {
                string taskname = "Elevator modeling";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                    myblock.ClickOnRecoverButton();
                }

                ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(myblock.TEMP_GetName(), taskname);
                    myblock.ClickOnDeleteButton();
                }
                
            }
        );
        }



        //[Fact]
        public void TaskDelete()
        {
            UITest(() =>
            {
                string taskname = "Simple addition";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                    myblock.ClickOnDeleteButton();
                }

                ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var myblock = blocks.FirstOrDefault(x => x.Get_DELETED_TaskName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(myblock.Get_DELETED_TaskName(), taskname);
                    myblock.ClickOnRecoverButton();
                }

            }
        );
        }



        //[Fact]
        public void TaskSolution()
        {
            UITest(() =>
            {
                string taskname = "Indexers";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var myblock = blocks.FirstOrDefault(x => x.TEMP_GetName().Equals(taskname, StringComparison.OrdinalIgnoreCase));
                    myblock.ClickOnSolutionButton();
                }
                var url = driver.GetCurrentUrl();
                Assert.Contains("ExerciseManagement/ExerciseSolutionsIndex/2", url);
            }
        );
        }




        //[Fact]
        public void TaskCreationDate()
        {
            UITest(() =>
            {
                string CreationDate = "09/07/2018";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();

                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var allblock = blocks.Where(x => x.TEMP_GetCreationDate().Equals(CreationDate, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(2,allblock.Count());
                }
            }
    );
        }

        //[Fact]
        public void TaskUpdateDate()
        {
            UITest(() =>
            {
                string UpdateDate = "09/07/2018";
                var ListOfTasks = ConstructPage<TeacherExerciseManagerPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var allblock = blocks.Where(x => x.TEMP_GetCreationDate().Equals(UpdateDate, StringComparison.OrdinalIgnoreCase));
                    Assert.Equal(2, allblock.Count());
                }
            }
);
        }


        //[Fact]
        public void AddNewTaskTest()
        {
            UITest(() =>
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
                    Assert.Equal(firstblock.GetName(), NEWTASK);
                }

                var NewTasks = ConstructPage<TeacherExerciseManagerPage>();
                var allblock = NewTasks.GetBlocks();
                if (allblock != null)
                {
                    var firstblock = allblock.FirstOrDefault(x => x.TEMP_GetName().Equals(NEWTASK, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnDeleteButton();
                }
            }
);
        }
    }
}
