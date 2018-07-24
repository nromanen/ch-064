namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int Day { get; set; }

        public string ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public string Month { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
