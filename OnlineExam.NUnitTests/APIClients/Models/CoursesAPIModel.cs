using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APIClients.Models
{
    public class CoursesAPIModel
    {
        public int id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }
}
