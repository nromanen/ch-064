using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OnlineExam.Framework;
using OnlineExam.Pages.POM;

namespace OnlineExam.NUnitTests
{
    public class CodeValidatorTest : BaseNTest
    {
        private SolutionCodePage solutionCodePage;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            string courseName = "C# Starter";
            var header = ConstructPage<Header>();
           LogProgress("Go to log in page");
            var logInPage = header.GoToLogInPage();
            LogProgress(
                "\n<br> " +
                $"Log in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
           LogProgress("Go to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
           LogProgress("get list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
               LogProgress($"search course with {courseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x =>
                    x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    firstBlock.ClickCourseLink();
                   LogProgress("Click on CourseName [link]");
                }
            }

            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"search task with {TaskName} name in list of tasks  ");
                var firstBlock =
                    blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstBlock.ClickOnTasksButton();
            }

            var taskViewPage = ConstructPage<TaskViewPage>();
            taskViewPage.ClickOnStartButton();
            solutionCodePage = ConstructPage<SolutionCodePage>();
        }


        [Test]
        public void CodeValidatorTestWithGoodCredentials()
        {
            var goodCredentials =
                "public class Program{    public static int Addition(int a, int b)    {        return a + b;    }}";
            var expectedText = "Pass";

           LogProgress("Send keys to field for code " + goodCredentials);
            solutionCodePage.SendKeysToFieldForCode(goodCredentials);

           LogProgress("Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

           LogProgress("Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }

        [Test]
        public void CodeValidatorTestWithBadCredentials()
        {
            var expectedText = "Compile errors";
            var badCredentials = "Bad code";

           LogProgress("Send keys to field for code " + badCredentials);
            solutionCodePage.SendKeysToFieldForCode(badCredentials);

           LogProgress("Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

           LogProgress("Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }

        [Test]
        public void CodeValidatorTestWithEmptyCredentials()
        {
            var expectedText = "Write some codeeeee";

           LogProgress("Send  empty keys to field for code ");
            solutionCodePage.SendKeysToFieldForCode(string.Empty);

           LogProgress("Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

           LogProgress("Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }
    }
}