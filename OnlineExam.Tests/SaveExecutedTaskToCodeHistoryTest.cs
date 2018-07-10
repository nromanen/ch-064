using AventStack.ExtentReports;
using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.CodeHistory.Favourites;
using OnlineExam.Pages.POM.UserDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    [Collection("MyTestCollection")]
    public class TestSaveExecutedTestToCodeHistory : BaseTest
    {
        private Header header;
        private LogInPage logInPage;
        private SideBar sideBar;


        public TestSaveExecutedTestToCodeHistory(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn("student3@gmail.com", Constants.STUDENT_PASSWORD);
            sideBar = ConstructPage<SideBar>();
            
        }

        [Fact]
          public void SaveExecutedTestToCodeHistory()
            {

            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("TestChangePassword");

                sideBar.GoToTasksPage();
                string TaskName = "Indexers";
                //var header = ConstructPage<Header>();
                //var logInPage = header.GoToLogInPage();
                //logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
               // NavigateTo("http://localhost:55842/CourseManagement/ShowExercise/2");
                //var nameOfExecutedTask = "";


                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();

                if (blocks != null)
                {

                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    //var nameOfExecutedTask = firstblock.GetName();
                    firstblock.ClickOnTasksButton();
                  
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnExecuteButton();
                    
                }
                var historyPage = ConstructPage<HistoryFavouritePage>();
                var blockHistory = historyPage.GetHistoryBlocks();

                bool blockOfExecutedCode = false;

                foreach (var block in blockHistory)
                {
                    if (block.GetTitle() == TaskName)
                    {
                        blockOfExecutedCode = true;
                        break;
                    }
                }
                //if (blocks != null)
                //{
                //    var blHistory = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                //}

                Assert.True(blockOfExecutedCode);
                fixture.test.Log(Status.Pass, "Code ia saved to history");
            });
        }
    }
}
