using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Framework
{
    public class Parameters
    {
    }

    public class TasksParams
    {
        public string TaskName { get; set; }
        public string CourseName { get; set; }
        public string NewTaskName { get; set; }
    }
    public class APICoursesParam
    {
        public string name { get; set; }
        public string description { get; set; }
        public string UserId { get; set; }
    }

}
