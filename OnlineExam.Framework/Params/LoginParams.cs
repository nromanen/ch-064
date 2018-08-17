using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework.Params
{
    public class LoginParams
    {
        public string StudentEmail { get; set; }
        public string StudentPassword { get; set; }
        public string Cookie { get; set; }
        public string FakeEmail { get; set; }
        public string FakePassword { get; set; }
    }
}
