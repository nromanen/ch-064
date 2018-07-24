namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exercises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercises()
        {
            UsersCode = new HashSet<UsersCode>();
        }

        public int Id { get; set; }

        public string Course { get; set; }

        public int CourseId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public double Rating { get; set; }

        public string TaskBaseCodeField { get; set; }

        public string TaskName { get; set; }

        public string TaskTextField { get; set; }

        public string TeacherId { get; set; }

        public string TestCasesCode { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdateDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersCode> UsersCode { get; set; }
    }
}
