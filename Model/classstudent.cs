namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classstudent")]
    public partial class classstudent
    {
        public int id { get; set; }

        public int studentid { get; set; }

        public double? discount { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public int sinif_id { get; set; }

        public virtual sinif sinif { get; set; }

        public virtual student student { get; set; }
    }
}
