using System;
using System.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpCore.model;


namespace OnlineExam.NUnitTests.RestClients
{
    public class Courses
    {
        public int id { get; set; }
        public string CreationDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string name { get; set; }
        public string UserId { get; set; }
    }

    [TestFixture]
    public class CoursesTest
    {
        [Test]
        public void CommentWhereIDEquals1()
        {
            var hz = new RestSharp.RestClient();
            var client = new RestClient();
            client.BaseUrl = new Uri("http://jsonplaceholder.typicode.com/");

            var request = new RestRequest("comments/1", Method.GET);
            request.AddUrlSegment("id", "1");

            var responseCommentModel = client.Execute<Comment>(request);

            Assert.AreEqual(1, responseCommentModel.Data.id,
                string.Format("ID {0} does not match actually {1}", 1, responseCommentModel.Data.id));
        }

        [Test]
        public void CommentWherePostIdEquals1()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://jsonplaceholder.typicode.com/");

            var request = new RestRequest("comments/1", Method.GET);
            request.AddUrlSegment("id", "1");

            IRestResponse<Comment> responseCommentModel = client.Execute<Comment>(request);

            Assert.AreEqual(1, responseCommentModel.Data.postId,
                string.Format("PostID {0} does not match actually {1}", 1, responseCommentModel.Data.postId));
        }


        [Test]
        public void CommentWhereBodyContainsIspam()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://jsonplaceholder.typicode.com/");

            var request = new RestRequest("comments/1", Method.GET);
            request.AddUrlSegment("id", "1");

            IRestResponse<Comment> responseCommentModel = client.Execute<Comment>(request);
            var assert = responseCommentModel.Data.body.Contains("ipsam");
            Assert.IsTrue(assert);
        }


        [Test]
        public void CommentEmailTest()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://jsonplaceholder.typicode.com/");

            var request = new RestRequest("comments/1", Method.GET);
            request.AddUrlSegment("id", "1");

            IRestResponse<Comment> responseCommentModel = client.Execute<Comment>(request);

            Assert.AreEqual("Eliseo@gardner.biz", responseCommentModel.Data.email,
                string.Format("Email {0} does not match {1}", "Eliseo@gardner.biz", responseCommentModel.Data.body));
        }
    }


}
