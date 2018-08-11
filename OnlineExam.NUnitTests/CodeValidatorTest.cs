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

            TestContext.Out.WriteLine("\n<br> " + "Send keys to field for code " + goodCredentials);
            solutionCodePage.SendKeysToFieldForCode(goodCredentials);

            TestContext.Out.WriteLine("\n<br> " + "Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

            TestContext.Out.WriteLine("\n<br> " + "Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }

        [Test]
        public void CodeValidatorTestWithBadCredentials()
        {
            var expectedText = "Compile errors";
            var badCredentials = "Bad code";

            TestContext.Out.WriteLine("\n<br> " + "Send keys to field for code " + badCredentials);
            solutionCodePage.SendKeysToFieldForCode(badCredentials);

            TestContext.Out.WriteLine("\n<br> " + "Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

            TestContext.Out.WriteLine("\n<br> " + "Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }

        [Test]
        public void CodeValidatorTestWithEmptyCredentials()
        {
            var expectedText = "Write some codeeeee";

            TestContext.Out.WriteLine("\n<br> " + "Send  empty keys to field for code ");
            solutionCodePage.SendKeysToFieldForCode(string.Empty);

            TestContext.Out.WriteLine("\n<br> " + "Click on execute button");
            solutionCodePage.ClickOnExecuteButton(expectedText);

            TestContext.Out.WriteLine("\n<br> " + "Getting text from result field");
            var resultOfCompilation = solutionCodePage.GetTextFromFieldWithResultOfCompilationCode();

            StringAssert.Contains(expectedText, resultOfCompilation,
                $"Message are not same expectedText:{expectedText},+ actualText {resultOfCompilation}");
        }
    }
}