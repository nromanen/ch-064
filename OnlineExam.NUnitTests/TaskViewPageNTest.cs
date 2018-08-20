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
    public class TaskViewPageNTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;
        private TaskViewPageParams TaskViewParams = ParametersResolver.Resolve<TaskViewPageParams>();



        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            var header = ConstructPage<Header>();
           LogProgress("Going to log in page");
            var logInPage = header.GoToLogInPage();
           LogProgress($"Logging in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
           LogProgress("Going to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
           LogProgress("getting list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
               LogProgress($"searching course with {TaskViewParams.CourseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(TaskViewParams.CourseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                   LogProgress("Clicking on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }


        [Test]
        public void ClickOnStartButton()
        {
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskViewParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskViewParams.TaskName, StringComparison.OrdinalIgnoreCase));
               LogProgress("Clicking on tasks button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
               LogProgress("Clicking on Start button");
                TaskView.ClickOnStartButton();
                var title = this.driver.GetCurrentTitle();
                Assert.AreEqual(TaskViewParams.BaseTitle, title, "\"Start\" button doesn't work, because of expected title isn't equal to actual title");
            }

        }


        [Test]
        public void ClickOnOkButton()
        {

            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskViewParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskViewParams.TaskName, StringComparison.OrdinalIgnoreCase));
               LogProgress("Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
               LogProgress("Clicking on OK button ");
                TaskView.ClickOnOkButton();
                var current_url = this.driver.GetCurrentUrl();
                bool f = false;
                if (current_url.Contains(TaskViewParams.Url)) f = true;
                Assert.That(f, "\"Ok\" button doesn't work, because of actual url doesn't contain expected url");
            }

        }


        [Test]
        public void EmailFromComment()
        {

            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskViewParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskViewParams.TaskName, StringComparison.OrdinalIgnoreCase));
               LogProgress("Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
               LogProgress("getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                   LogProgress($"searching comment with email '{TaskViewParams.Email}' in list of comments");
                    var anyblock = divs.Any(x => x.GetEmail().Equals(TaskViewParams.Email, StringComparison.OrdinalIgnoreCase));
                    Assert.True(anyblock, "There is any comments from user with this email");
                    var comment = new CommentDAL();
                    TestContext.Out.WriteLine("\n<br> " + $"Searching comment with user's email '{TaskViewParams.Email}' in database");
                    var result = comment.IsTaskPresentedByEmail(TaskViewParams.Email);
                    Assert.True(result, $"comment with user's email '{TaskViewParams.Email}' in't available in database");

                }
            }
        }

        [Test]
        public void TextFromComment()
        {
            var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskViewParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskViewParams.TaskName, StringComparison.OrdinalIgnoreCase));
               LogProgress("Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
               LogProgress("getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                   LogProgress($"searching comment with text '{TaskViewParams.Comment}' in list of comments");
                    var b = divs.FirstOrDefault(x => x.GetCommentText().Equals(TaskViewParams.Comment, StringComparison.OrdinalIgnoreCase));
                    var CommentText = b.GetCommentText();
                    Assert.AreEqual(TaskViewParams.Comment, CommentText, "There is any comments with this comment text");
                    var comment = new CommentDAL();
                    TestContext.Out.WriteLine("\n<br> " + $"Searching comment with comment text '{CommentText}' in database");
                    var result = comment.IsTaskPresentedByCommentText(CommentText);
                    Assert.True(result, $"comment with comment text '{CommentText}' in't available in database");

                }
            }

        }

        [Test]
        public void StarsCount()
        {

           var ListOfTasks = ConstructPage<TasksPage>();
           LogProgress("getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
               LogProgress($"searching task with {TaskViewParams.TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x =>                    x.GetName().Equals(TaskViewParams.TaskName, StringComparison.OrdinalIgnoreCase));
               LogProgress("Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
               LogProgress("getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                   LogProgress($"searching comment with email '{TaskViewParams.Email}' in list of comments");
                    var anyblock = divs.FirstOrDefault(x => x.GetEmail().Equals(TaskViewParams.Email, StringComparison.OrdinalIgnoreCase));
                    var count = anyblock.GetStarsss().ToString();
                    Assert.AreEqual(TaskViewParams.Stars, count, "there is any comments with rate of this count stars");
                }
            }

        }
    }
}