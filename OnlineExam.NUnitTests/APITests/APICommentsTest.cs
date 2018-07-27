using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
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
        RestClient client = new RestClient($"http://localhost:55842/swagger/index.html?url=/swagger/v1/swagger.json#/");

        [Test]
        public void GetComment(int commentId)
        {
            var request = new RestRequest("/api/CommentApi", Method.GET);
            var response = client.Execute(request);
            var result = response.Content;
            var actual = new CommentDAL().GetCommentById(commentId.ToString());
            Assert.True(result.StartsWith(actual.UserName));
        }

        [Test]
        public void Post()
        {
            var request = new RestRequest("/api/CommentApi", Method.POST);
            request.AddHeader("content-type", "application/json");
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
            var actual = new CommentDAL().GetCommentById(obj.id.ToString());
            Assert.AreEqual(actual.UserName, obj.userName);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = response.Content;
            Assert.NotNull(result);
            //123
        }
    }
}