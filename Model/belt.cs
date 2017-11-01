namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("belt")]
    public partial class belt
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int beltcolorid { get; set; }

        public int? order { get; set; }

        public int? branchid { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public virtual beltColor beltColor { get; set; }

        public virtual branch branch { get; set; }
    }
}
