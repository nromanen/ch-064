//using System;
//using System.Linq;
//using NUnit.Framework;
//using RestSharp;

//namespace OnlineExam.NUnitTests.RestClients
//{
//    public class Courses
//    {
//        public int id { get; set; }
//        public string CreationDate { get; set; }
//        public string Description { get; set; }
//        public bool IsActive { get; set; }
//        public string name { get; set; }
//        public string UserId { get; set; }
//    }

//    [TestFixture]
//    public class CoursesTest
//    {
//        [Test]
//        public void CoursesID()
//        {
//            var client = new RestClient();
//            client.BaseUrl = new Uri("http://localhost:55842");

//            var request = new RestRequest("/api/Course", Method.GET);
//            request.AddUrlSegment("id", "");

//            var responseCourseModel = client.Execute<Courses>(request);
//            var result = responseCourseModel.Content;
//            Assert.NotNull(result);

//           // Assert.AreEqual(1, responseCourseModel.Data.id);//string.Format("ID {0} does not match actually {1}", 1, responseCourseModel.Data.id));
//        }

//        [Test]
//        public void CourseCreationDate()
//        {
//            var client = new RestClient();
//            client.BaseUrl = new Uri("http://localhost:55842");

//            var request = new RestRequest("/CourseManagement", Method.GET);
//            request.AddUrlSegment("id", "1");

//            IRestResponse<Courses> responseCommentModel = client.Execute<Courses>(request);

//            Assert.AreEqual(1, responseCommentModel.Data.CreationDate,
//                string.Format("PostID {0} does not match actually {1}", 1, responseCommentModel.Data.CreationDate));
//        }

//        [Test]
//        public void CoursesPOST()
//        {
//            var client = new RestClient();
//            client.BaseUrl = new Uri("http://localhost:55842");
//            var loginRequest = new RestRequest("/swagger.json#/Course/Course_Create", Method.POST);
//            loginRequest.AddHeader("content-type", "application/json");
//            string json = @"{
//             ""Id"": 11,
//             ""CreationDate"":""2018-07-24 16:02:30.9193083"",
//             ""Description"" : ""camon"",
//             ""IsActive"" : ""True"",
//             ""Name"" : ""NAME"",
//             ""UserId"" : ""e43b63ea-3492-454b-9517-8c62ae65c598""
//                }";

//            loginRequest.AddParameter("text/json", json, ParameterType.RequestBody);
//            IRestResponse response = client.Execute(loginRequest);
//            Assert.NotNull(response);
//        }
//    }
//}
