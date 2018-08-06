using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APIClients.Models
{
    public class NewsAPIModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public int courseId { get; set; }
    }
}
