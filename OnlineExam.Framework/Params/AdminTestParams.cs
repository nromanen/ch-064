using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework.Params
{
    public class AdminTestParams
    {
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string UserForDeleteEmail { get; set; }
        public string UserForChangeRoleEmail { get; set; }
        public string UserPassword { get; set; }
        public string TeacherRole { get; set; }
        public string StudentEmail { get; set; }
    }
}
