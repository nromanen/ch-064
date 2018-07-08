using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineExam.Tests
{
    [CollectionDefinition("MyTestCollection")]
    public class TestCollectionOE : ICollectionFixture<BaseFixture>
    {
    }
}