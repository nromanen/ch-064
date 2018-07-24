namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CodeHistories
    {
        public int Id { get; set; }

        public string CodeText { get; set; }

        public string Error { get; set; }

        public bool IsFavouriteCode { get; set; }

        public string Result { get; set; }

        public int UserCodeId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime time { get; set; }

        public virtual UsersCode UsersCode { get; set; }
    }
}
