using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OnlineExam.DatabaseHelper;
using OnlineExam.DatabaseHelper.DAL;
using OnlineExam.NUnitTests.APIClients;

namespace OnlineExam.NUnitTests.APITests
{
    [TestFixture]
    public class APIUsersTest
    {
        private APIUsersClient client;

        [SetUp]
        public void SetUp()
        {
            client = new APIUsersClient();
        }


        [Test]
        public void ChangeNameTest()
        {
            var obj = new
            {
                id = "7a72f372-b3bd-4391-b075-1510e34b98da",
                email = "UserForChangeNameAPI@gmail.com",
                password = "User_123",
                newUserName = "ApiTestNew"
            };
            var result = client.PostChange(obj, "name");
            Assert.AreEqual("OK", result);
            var actual = new UserDAL().GetUserById(obj.id);
            Assert.AreEqual(actual.UserName, obj.newUserName);
        }

        [Test]
        public void ChangeEmailTest()
        {
            var obj = new
            {
                id = "6734ae72-eb95-46f0-82fe-4bf62ea52210",
                oldEmail = "UserForChangeEmailAPI@gmail.com",
                password = "User_123",
                newEmail = "UserTestAPI@gmail.com"
            };
            var result = client.PostChange(obj, "email");
            Assert.AreEqual("OK", result);
            var actual = new UserDAL().GetUserById(obj.id);
            Assert.AreEqual(obj.newEmail, actual.Email);
        }
    }
}