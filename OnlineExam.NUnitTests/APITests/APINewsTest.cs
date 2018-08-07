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
    [TestFixture]
    public class APINewsTest
    {
        private APINewsClient client;

        [Test]
        public void GetNews()
        {
            
            client = new APINewsClient();
            var news = client.Get();
            Assert.NotNull(news);
           
            var actual = new NewsDAL().GetNews();
            
            Assert.AreEqual(news.Count, actual.Count);
            foreach (var x in actual)
            {
                var apiItem = news.FirstOrDefault(z => z.id == x.Id);
                Assert.NotNull(apiItem);
                StringAssert.AreEqualIgnoringCase(x.Title, apiItem.title);
                StringAssert.AreEqualIgnoringCase(x.Text, apiItem.text);
            }
        }

        [Test]
        public void Post()
        {
            string title = Guid.NewGuid().ToString();

            var obj = new
            {
                Text = "text",
                Title = title,
                Course = "C# Starter",
            };
            client = new APINewsClient();
            var status = client.Post(obj);
            Assert.AreEqual(HttpStatusCode.OK, status);

            var actual = new NewsDAL().GetNewsByTitle(obj.Title.ToString());
        
            Assert.NotNull(actual);
            StringAssert.AreEqualIgnoringCase(obj.Text, actual.Text);
            StringAssert.AreEqualIgnoringCase(obj.Course, actual.Courses.Name);
        }
}
}