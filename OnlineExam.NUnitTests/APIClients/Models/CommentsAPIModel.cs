using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.NUnitTests.APIClients.Models
{
    public class CommentsAPIModel
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public DateTime CreationDateTime { get; set; }

        public int ExerciseId { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
