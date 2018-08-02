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
        public void GetComment(int commentId)
        {
            client = new APICommentsClient();
            client.Get();
            var actual = new CommentDAL().GetCommentById(commentId.ToString());
            Assert.Equals(actual.Id, commentId);
        }

        [Test]
        public void Post()
        {
            var obj = new
            {
                id = 1,
                userId = 1,
                userName = "Name",
                commentText = "Comment",
                creationDateTime = new DateTime(12, 06, 2018),
                exerciseId = 2,
                rating = 3,
            };
            client = new APICommentsClient();
            client.Post(obj);
            var actual = new CommentDAL().GetCommentById(obj.id.ToString());
            Assert.AreEqual(actual.UserName, obj.userName);
        }
    }
}