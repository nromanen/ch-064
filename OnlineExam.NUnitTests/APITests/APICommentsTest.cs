using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APITests
{
    [Category("APITests")]
    [TestFixture]
    public class APICommentsTest
    {
        private APICommentsClient client;

        [SetUp]
        public void SetUp()
        {
            client = new APICommentsClient();
        }

        [Test]
        public void GetComment()
        {
            var commentId = 1;
            client = new APICommentsClient();
            client.Get(commentId);
            var actual = new CommentDAL().GetCommentById(commentId);
            Assert.AreEqual(actual.Id, commentId);
        }

        [Test]
        public void Post()
        {
            Guid g = new Guid();
            var obj = new
            {
                userId = "90b47207-4762-4886-a2cf-64dd84aceeb41",
                userName = "student@gmail.com",
                commentText = $"Comment {g}",
                exerciseId = 1,
                rating = 0,
            };
            client = new APICommentsClient();
            client.Post(obj);
            var actual = new CommentDAL().GetCommentByCommentText(obj.commentText.ToString());
            Assert.AreEqual(actual.CommentText, obj.commentText);
        }
    }
}