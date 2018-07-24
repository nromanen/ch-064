namespace OnlineExam.DatabaseHelper
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public string FromEmail { get; set; }

        public string InboxText { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsInBox { get; set; }

        public bool IsNew { get; set; }

        public string OutboxText { get; set; }

        public string Subject { get; set; }

        public string ToEmail { get; set; }
    }
}
