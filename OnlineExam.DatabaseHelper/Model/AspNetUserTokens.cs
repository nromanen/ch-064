namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserTokens
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(450)]
        public string Name { get; set; }

        public string Value { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
