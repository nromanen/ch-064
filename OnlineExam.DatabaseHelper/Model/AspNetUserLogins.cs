namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserLogins
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(450)]
        public string LoginProvider { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(450)]
        public string ProviderKey { get; set; }

        public string ProviderDisplayName { get; set; }

        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
