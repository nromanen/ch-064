using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework.Params
{
    public class RegisterParams
    {
        public string LocalEmail { get; set; }
        public string ExampleEmail { get; set; }
        public string ExamplePassword { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string Cookie { get; set; }
        public string StudentEmail { get; set; }
    }
}
