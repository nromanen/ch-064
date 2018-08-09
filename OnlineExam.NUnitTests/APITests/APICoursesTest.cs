using NUnit.Framework;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;
using System;
using System.Net;

namespace OnlineExam.NUnitTests.APITests
{
    [Category("APITests")]
    [TestFixture]
    public class APICoursesTest : BaseAPITest
    {
        private APICoursesClient client;

        [SetUp]
        public void SetUp()
        {
            base.SetUp();
            client = new APICoursesClient();
        }

        [Test]
        public void GetCourse()
        {
            client = new APICoursesClient();
            var Getcourse = client.Get();
            Assert.AreEqual(HttpStatusCode.OK, Getcourse.Code, "Method get doesn't work, because of Invalid result status");
        }

        [Test]
        public void Post()
        {
            var guid = new Guid().ToString();
            var obj = new
            {
                name = $"C# CourseName {guid}",
                description = "Description for new Course",
                UserId = "c557d51b-2a7e-46b4-8ed0-fe9253d8f861"
            };

            client = new APICoursesClient();
            var result = client.Post(obj);
            Assert.NotNull(result);
            Assert.AreEqual(result, HttpStatusCode.OK);
            var actual = new CoursesDAL().GetCourseByCourseName(obj.name);
            var actualDescription = actual.Description;
            Assert.AreEqual(obj.description, actualDescription, "Method post doesn't work, because of expected course name isn't equal actual course name");
        } 
    }
}