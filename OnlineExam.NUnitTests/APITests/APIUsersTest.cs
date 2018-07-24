using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OnlineExam.NUnitTests.APIClients;

namespace OnlineExam.NUnitTests.APITests
{
    [TestFixture]
    public class APIUsersTest
    {
        private string json = @"{""id"":""88d0300e-0520-447c-b117-cde051119565"",""email"":""UserForChangeNameAPI@gmail.com"", ""password"": ""User_123"", ""newUserName"": ""ApiTest"",}";




        private APIUsersClient client;



        [Test]
        public void ChangeNameTest()
        {
            client = new APIUsersClient();
            var result = client.PostChange(json, "name");
            Assert.NotNull(result);
        }
    }
}