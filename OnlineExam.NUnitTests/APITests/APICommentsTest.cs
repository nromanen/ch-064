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
       /// <summary>
       /// Get API from Comments by Id
       /// </summary>
        [Test]
        public void GetComment()
        {
            //If I'd cry about this test failing, please tell me I'm moron and to change URL in configfile.
            client = new APICommentsClient();
            var getMethod = client.Get(9);
            //Assert.AreEqual(actual.Id, commentId, "Actual id isn't equal to expected id.");
            Assert.AreEqual(HttpStatusCode.OK, getMethod.Code, "Invalid result status");
        }

        [Test]
        public void PostComment()
        {
            var obj = new
            {
                userId = "90b47207-4762-4886-a2cf-64dd84aceeb41",
                userName = "student@gmail.com",
                commentText = $"Comment {Guid.NewGuid()}",
                exerciseId = 1,
                rating = 0,
            };
            client = new APICommentsClient();
            var statusCode = client.Post(obj);
            Assert.AreEqual(statusCode, HttpStatusCode.OK, "Status code isn't Ok.");
            var actual = new CommentDAL().GetCommentByCommentText(obj.commentText.ToString());
            Assert.AreEqual(actual.UserId, obj.userId, "Actual user id isn't equal to expected user id.");
            Assert.AreEqual(actual.UserName, obj.userName, "Actual user name isn't equal to expected user name.");
        }
    }
}