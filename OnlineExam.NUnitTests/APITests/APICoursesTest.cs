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
            client = new APICoursesClient();
        }

        [Test]
        public void GetCourse()
        {
            string CourseName = "C# Essential";
            client = new APICoursesClient();
            client.Get();
            var actual = new CoursesDAL().GetCourseByCourseName(CourseName);
            Assert.AreEqual(actual.Name, CourseName);
        }

        [Test]
        public void Post()
        {
            var guid = new Guid().ToString();
            var obj = new
            {
                name = $"C# CourseName1 {guid}",
                description = "Description for new Course1",
                UserId = "c557d51b-2a7e-46b4-8ed0-fe9253d8f861"
            };

            client = new APICoursesClient();
            var result = client.Post(obj);
            Assert.AreEqual(result, HttpStatusCode.OK);
            var actual = new CoursesDAL().GetCourseByCourseName(obj.name);
            Assert.NotNull(actual);
            Assert.AreEqual(actual.Description, obj.description);
        }

        //[Test]
        //public void Delete()
        //{
        //    int CourseId = 2;
        //    client = new APICoursesClient();
        //    client.Delete(CourseId);
        //    var actual = new CoursesDAL().GetCourseByCourseID(CourseId.ToString());
        //    Assert.IsEmpty(actual.ToString());
        //}
    }
}