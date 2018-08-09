using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APITests
{
    [Category("APITests")]
    [TestFixture]
    public class APICommentsTest : BaseAPITest
    {
        private APICommentsClient client;
       
        [Test]
        public void GetComment()
        {
            client = new APICommentsClient();
            var getMethod = client.Get(1);
            //Assert.AreEqual(actual.Id, commentId, "Actual id isn't equal to expected id.");
            Assert.AreEqual(HttpStatusCode.OK, 
                getMethod.Code, "Invalid result status");
        }

        [Test]
        public void PostComment()
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
            Assert.AreEqual(actual.CommentText, obj.commentText, "Actual comment text isn't equal to expected comment text.");
        }
    }
}