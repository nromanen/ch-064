using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APIClients
{
    public class RestResultTyped<T> : RestResult
    {
        public T Data { get; set; }
    }
}
