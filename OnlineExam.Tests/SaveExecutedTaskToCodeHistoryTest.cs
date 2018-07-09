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
        private UserInfoPage userInfo;


        public TestSaveExecutedTestToCodeHistory(BaseFixture fixture) : base(fixture)
        {
            BeginTest();

            header = ConstructPage<Header>();
            logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.TEACHER_EMAIL, Constants.TEACHER_PASSWORD);
            userInfo = header.GoToUserAccountPage();
        }

        [Fact]
          public void SaveExecutedTestToCodeHistory()
            {

            UITest(() =>
            {
                fixture.test = fixture.extentReports.CreateTest("TestChangePassword");

                string TaskName = "Simple addition";
                var header = ConstructPage<Header>();
                var logInPage = header.GoToLogInPage();
                logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
                NavigateTo("http://localhost:55842/CourseManagement/ShowExercise/1");
                var ListOfTasks = ConstructPage<TasksPage>();
                string nameOfExecutedTask = "";

                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    nameOfExecutedTask = firstblock.GetName();
                    firstblock.ClickOnTasksButton();
                    Thread.Sleep(2000);
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    Thread.Sleep(2000);
                    var Code = ConstructPage<SolutionCodePage>();
                    Code.ClickOnExecuteButton();
                    Thread.Sleep(2000);
                }
                var historyPage = ConstructPage<HistoryFavouritePage>();
                var blocksHistory = historyPage.GetHistoryBlocks();

                //bool blockOfExecutedCode = false;

                //foreach (var block in blocksHistory)
                //{
                //    if (block.GetName == nameOfExecutedTask)
                //    {
                //        blockOfExecutedCode = true;
                //        break;
                //    }
                //}
                //Assert.True(blockOfExecutedCode);
                //fixture.test.Log(Status.Pass, "Code ia saved to history");
            });
        }
    }
}
