namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersCode")]
    public partial class UsersCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersCode()
        {
            CodeHistories = new HashSet<CodeHistories>();
        }

        public int Id { get; set; }

        public int CodeStatus { get; set; }

        public string CodeText { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndTime { get; set; }

        public int ExerciseId { get; set; }

        public int Mark { get; set; }

        public string TeachersComment { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodeHistories> CodeHistories { get; set; }

        public virtual Exercises Exercises { get; set; }
    }
}
