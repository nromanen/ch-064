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
    [Category("APITests")]
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
                id = "4ca71f95-ffc0-43e7-9294-635717d03905",
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
                id = "8e5f2be9-037a-4e66-9980-d416284bd5d8",
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