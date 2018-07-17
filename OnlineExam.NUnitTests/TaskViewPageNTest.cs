using OnlineExam.Pages.POM;
using OnlineExam.Pages.POM.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class TaskViewPageNTest : BaseNTest
    {
        private Header header;
        private SideBar sidebar;
        private CourseManagementPage CoursesList;


        [SetUp]
        public void SetUp()
        {
            BeginTest();

            string courseName = "C# Essential";
            var header = ConstructPage<Header>();
            var logInPage = header.GoToLogInPage();
            logInPage.SignIn(ConstantsN.STUDENT_EMAIL, ConstantsN.STUDENT_PASSWORD);
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
            UITest(() =>
            {
                string TaskName = "Indexers";

                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x =>
                        x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnStartButton();
                    var title = this.driver.GetCurrentTitle();
                    Assert.AreEqual("- WebApp", title);
                }
            }
            );
        }


        [Test]
        public void ClickOnOkButton()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";

                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x =>
                        x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnOkButton();
                    var current_url = this.driver.GetCurrentUrl();
                    bool f = false;
                    if (current_url.Contains("/CourseManagement/ShowExercise/2")) f = true;
                    Assert.That(f);
                }
            }
            );
        }


        [Test]
        public void EmailFromComment()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                string email = "student@gmail.com";

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
                        var anyblock = divs.Any(x => x.GetEmail().Equals(email, StringComparison.OrdinalIgnoreCase));
                        Assert.True(anyblock);
                    }
                }
            }
            );
        }

        [Test]
        public void TextFromComment()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                string coment = "First comment";

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
                        var b = divs.FirstOrDefault(x =>
                            x.GetCommentText().Equals(coment, StringComparison.OrdinalIgnoreCase));
                        Assert.AreEqual(b.GetCommentText(), coment);
                    }
                }
            }
            );
        }

        [Test]
        public void DateFromComment()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                string email = "student@gmail.com";


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
                        var date = anyblock.GetCommentDate();
                        Assert.AreEqual("7/10/2018 6:28:20 PM", date.ToString());
                    }
                }
            }
            );
        }

        [Test]
        public void ShowHideComments()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";

                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x =>
                    x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.ClickOnShowHideCommentsButton();
                    Wait(1000);
                    TaskView.ClickOnShowHideCommentsButton();
                }
            }
            );
        }


        [Test]
        public void StarsCount()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                string email = "student@gmail.com";


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
                        var count = anyblock.GetStarsss();
                        Assert.AreEqual("5", count.ToString());
                    }
                }
            }
            );
        }


        [Test]
        public void CreateNewComment()
        {
            UITest(() =>
            {
                string TaskName = "Indexers";
                string coment = "rate 4 stars";


                var ListOfTasks = ConstructPage<TasksPage>();
                var blocks = ListOfTasks.GetBlocks();
                if (blocks != null)
                {
                    var firstblock = blocks.FirstOrDefault(x =>
                        x.GetName().Equals(TaskName, StringComparison.OrdinalIgnoreCase));
                    firstblock.ClickOnTasksButton();
                    var TaskView = ConstructPage<TaskViewPage>();
                    TaskView.CreateCommentText(coment);
                    TaskView.Click_4_Star();
                    TaskView.ClickOnCommentButton();
                    driver.RefreshPage();
                    TaskView = ConstructPage<TaskViewPage>();
                    var divs = TaskView.GetDivs();
                    if (divs != null)
                    {
                        var anyblock = divs.FirstOrDefault(x =>
                            x.GetCommentText().Equals(coment, StringComparison.OrdinalIgnoreCase));
                        var comment = anyblock.GetCommentText();
                        Assert.AreEqual(comment.ToString(), coment);
                    }
                }
            }
            );
        }
    }
}