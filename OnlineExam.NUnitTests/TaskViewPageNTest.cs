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
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(Constants.STUDENT_EMAIL, Constants.STUDENT_PASSWORD);
            var sidebar = ConstructPage<SideBar>();
            sidebar.GoToCourseManagementPage();
            var CoursesList = ConstructPage<CourseManagementPage>();
            var block = CoursesList.GetBlocks();
            if (block != null)
            {
                var firstBlock = block.FirstOrDefault(x =>
                    x.GetCourseName().Equals(courseName, StringComparison.OrdinalIgnoreCase));

                if (firstBlock != null)
                {
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var anyblock = divs.Any(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    Assert.True(anyblock, "There is any comments from user with this email");
                }
            }
        }

        [Test]
        public void TextFromComment()
        {

            string TaskName = "Indexers";
            string ExpectedComent = "First comment";

            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var b = divs.FirstOrDefault(x => x.GetCommentText().Equals(ExpectedComent, StringComparison.OrdinalIgnoreCase));
                    var CommentText = b.GetCommentText();
                    Assert.AreEqual(ExpectedComent, CommentText, "There is any comments with this comment text");
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var anyblock = divs.FirstOrDefault(x =>
                        x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    var Actualdate = anyblock.GetCommentDate().ToString();
                    Assert.AreEqual(date, Actualdate,"There is any comments with this date");
                }
            }

        }

        [Test]
        public void ShowHideComments()
        {

            string TaskName = "Indexers";

            var ListOfTasks = ConstructPage<TasksPage>();
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x => x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                TaskView.ClickOnShowHideCommentsButton();
                Wait(1000);
                TaskView = ConstructPage<TaskViewPage>();
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var anyblock = divs.Any(x => x.GetEmail().Equals("student@gmail.com", StringComparison.OrdinalIgnoreCase));
                    Assert.False(anyblock,"there is any comments from user with this email");
                }
                TaskView.ClickOnShowHideCommentsButton();
                Wait(1000);
                TaskView = ConstructPage<TaskViewPage>();
                divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var anyblock = divs.Any(x => x.GetEmail().Equals("student@gmail.com", StringComparison.OrdinalIgnoreCase));
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
            var blocks = ListOfTasks.GetBlocks();
            if (blocks != null)
            {
                var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                firstblock.ClickOnTasksButton();
                var TaskView = ConstructPage<TaskViewPage>();
                var divs = TaskView.GetDivs();
                if (divs != null)
                {
                    var anyblock = divs.FirstOrDefault(x =>
                        x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                    var count = anyblock.GetStarsss().ToString();
                    Assert.AreEqual(StarsCount, count, "there is any comments with rate of this count stars");
                }
            }

        }
    }
}