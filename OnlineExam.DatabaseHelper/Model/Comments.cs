namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreationDateTime { get; set; }

        public int ExerciseId { get; set; }

        public int? Rating { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
