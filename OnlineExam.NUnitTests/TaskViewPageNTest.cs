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
    public class TaskViewPageNTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;


        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            string courseName = "C# Essential";
            var header = ConstructPage<Header>();
            TestContext.Out.WriteLine("\n<br> " + "Going to log in page");
            var logInPage = header.GoToLogInPage();
            TestContext.Out.WriteLine("\n<br> " + $"Logging in as student: email {Constants.STUDENT_EMAIL}, password {Constants.STUDENT_PASSWORD}");
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            TestContext.Out.WriteLine("\n<br> " + "Going to the course managment page");
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of courses");
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching course with {courseName} name in list of courses  ");
                var firstBlock = block.FirstOrDefault(x => x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + "Clicking on CourseName [link]");
                    firstBlock.ClickCourseLink();
                }
            }
        }


        [Test]
        public void ClickOnStartButton()
        {
            string TaskName = "Indexers";
            string Basetitle = "- WebApp";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Clicking on tasks button");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "Clicking on Start button");
                TaskView.ClickOnStartButton();
                var title = this.driver.GetCurrentTitle();
                Assert.AreEqual(Basetitle, title, "\"Start\" button doesn't work, because of expected title isn't equal to actual title");
            }

        }


        [Test]
        public void ClickOnOkButton()
        {

            string TaskName = "Indexers";
            string ContainUrl = "/CourseManagement/ShowExercise/2";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "Clicking on OK button ");
                TaskView.ClickOnOkButton();
                var current_url = this.driver.GetCurrentUrl();
                bool f = false;
                if (current_url.Contains(ContainUrl)) f = true;
                Assert.That(f, "\"Ok\" button doesn't work, because of actual url doesn't contain expected url");
            }

        }


        [Test]
        public void EmailFromComment()
        {

            string TaskName = "Indexers";
            string email = "student@gmail.com";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"searching comment with email '{email}' in list of comments");
                    var anyblock = divs.Any(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    Assert.True(anyblock, "There is any comments from user with this email");
                    var comment = new CommentDAL();
                    TestContext.Out.WriteLine("\n<br> " + $"Searching comment with user's email '{email}' in database");
                    var result = comment.IsTaskPresentedByEmail(email);
                    Assert.True(result, $"comment with user's email '{email}' in't available in database");

                }
            }
        }

        [Test]
        public void TextFromComment()
        {
            string TaskName = "Indexers";
            string ExpectedComent = "First comment";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"searching comment with text '{ExpectedComent}' in list of comments");
                    var b = divs.FirstOrDefault(x => x.GetCommentText().Equals(ExpectedComent, StringComparison.OrdinalIgnoreCase));
                    var CommentText = b.GetCommentText();
                    Assert.AreEqual(ExpectedComent, CommentText, "There is any comments with this comment text");
                    var comment = new CommentDAL();
                    TestContext.Out.WriteLine("\n<br> " + $"Searching comment with comment text '{CommentText}' in database");
                    var result = comment.IsTaskPresentedByCommentText(CommentText);
                    Assert.True(result, $"comment with comment text '{CommentText}' in't available in database");

                }
            }

        }

        [Test]
        public void DateFromComment()
        {
            string TaskName = "Indexers";
            string email = "student@gmail.com";
            string date = "7/10/2018 6:28:20 PM";


            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "getting list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"searching task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Clicking on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "getting list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"searching comment with email '{email}' in list of comments");
                    var anyblock = divs.FirstOrDefault(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    var Actualdate = anyblock.GetCommentDate().ToString();
                    Assert.AreEqual(date, Actualdate,"There is any comments with this date");
                    var comment = new CommentDAL();
                    TestContext.Out.WriteLine("\n<br> " + $"Searching comment with creation date '{date}' in database");
                    var result = comment.IsTaskPresentedByCreatingDate(date);
                    Assert.True(result, $"comment with creating date '{date}' in't available in database");

                }
            }

        }

        [Test]
        public void ShowHideComments()
        {

            string TaskName = "Indexers";
            string email = "student@gmail.com";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "Click on 'Show/Hide' button");
                TaskView.ClickOnShowHideCommentsButton();
                TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "get list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"search comment with email '{email}' in list of comments");
                    var anyblock = divs.Any(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    Assert.False(anyblock,"there is any comments from user with this email");
                }
                TestContext.Out.WriteLine("\n<br> " + "Click on 'Show/Hide' button");
                TaskView.ClickOnShowHideCommentsButton();
                Wait(1000);
                TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "get list of comments");
                divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"search comment with email '{email}' in list of comments");
                    var anyblock = divs.Any(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    Assert.True(anyblock, "there is any comments from user with this email");
                }
            }

        }


        [Test]
        public void StarsCount()
        {

            string TaskName = "Indexers";
            string email = "student@gmail.com";
            string StarsCount = "5";

            var ListOfTasks = ConstructPage<TasksPage>();
            TestContext.Out.WriteLine("\n<br> " + "get list of tasks");
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                TestContext.Out.WriteLine("\n<br> " + $"search task with {TaskName} name in list of tasks  ");
                var firstblock = blocks.FirstOrDefault(x =>                    x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                TestContext.Out.WriteLine("\n<br> " + "Click on tasks button ");
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TestContext.Out.WriteLine("\n<br> " + "get list of comments");
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    TestContext.Out.WriteLine("\n<br> " + $"search comment with email '{email}' in list of comments");
                    var anyblock = divs.FirstOrDefault(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    var count = anyblock.GetStarsss().ToString();
                    Assert.AreEqual(StarsCount, count, "there is any comments with rate of this count stars");
                }
            }

        }
    }
}