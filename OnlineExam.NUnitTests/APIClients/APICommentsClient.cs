using NUnit.Framework;
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
        public void GetComment(int taskId)
        {
            var request = new RestRequest("/api/CommentApi", Method.GET);
            request.AddUrlSegment("id", taskId);
            var response = client.Execute(request);
            var result = response.Content;
            Assert.NotNull(result);
        }

        [Test]
        public void Post()
        {
            var request = new RestRequest("/api/CommentApi", Method.POST);
            request.AddHeader("content-type", "application/json");
            string json = @"{
                                ""id"": 1,
                                ""userId"": 1,
                                ""userName"": ""Name"",
                                ""commentText"": ""Comment"",
                                ""creationDateTime"": 12.06.2018,
                                ""exerciseId"": 2,
                                ""rating"": 3,
                            }";

            request.AddParameter("text/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var result = response.Content;
            Assert.NotNull(result);
            //123
        }
    }
}