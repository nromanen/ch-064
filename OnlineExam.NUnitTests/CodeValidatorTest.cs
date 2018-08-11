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
            TestContext.Out.WriteLine("\n<br> " + "Go to log in page");
            var logInPage = header.GoToLogInPage();
            TestContext.Out.WriteLine(
                "\n<br> " +
                $"Log in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            TestContext.Out.WriteLine("\n<br> " + "Go to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search course with {courseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x =>
                    x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    firstBlock.ClickCourseLink();
                    TestContext.Out.WriteLine("\n<br> " + "Click on CourseName [link]");
                }
            }

            string TaskName = "Simple addition";
            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
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
            solutionCodePage.SendKeysToFieldForCode(goodCredentials);
            solutionCodePage.ClickOnExecuteButton(expectedText);
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();
            StringAssert.Contains(expectedText, resultOfCompilation);
        }

        [Test]
        public void CodeValidatorTestWithBadCredentials()
        {
            var compileErrors = "Compile errors";
            var badCredentials = "Bad code";
            solutionCodePage.SendKeysToFieldForCode(badCredentials);
            solutionCodePage.ClickOnExecuteButton(compileErrors);
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();
            StringAssert.Contains(compileErrors, resultOfCompilation);
        }

        [Test]
        public void CodeValidatorTestWithEmptyCredentials()
        {
            var message = "Write some codeeeee";
            solutionCodePage.SendKeysToFieldForCode(string.Empty);
            solutionCodePage.ClickOnExecuteButton(message);
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();
            StringAssert.Contains(message, resultOfCompilation);
        }
    }
}