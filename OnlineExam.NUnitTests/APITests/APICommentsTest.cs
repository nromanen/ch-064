using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests
{
    [TestFixture]
    public class CommentClient
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
            var actual = new CommentDAL().GetCommentById(commentId.ToString());
            Assert.Equals(actual.Id, commentId);
        }

        [Test]
        public void Post()
        {
            var obj = new
            {
                userId = 1,
                userName = "Name",
                commentText = $"Comment {new Guid()}",
                creationDateTime = new DateTime(2001, 06, 01, 00, 00, 00),
                exerciseId = 2,
                rating = 3,
            };
            client = new APICommentsClient();
            client.Post(obj);
            var actual = new CommentDAL().GetCommentByCommentText(obj.commentText.ToString());
            Assert.AreEqual(actual.UserName, obj.userName);
        }
    }
}