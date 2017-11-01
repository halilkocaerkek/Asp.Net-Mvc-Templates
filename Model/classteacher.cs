namespace DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classteacher")]
    public partial class classteacher
    {
        public int id { get; set; }

        public int classid { get; set; }

        public int teacherid { get; set; }

        public bool? isClassAdmin { get; set; }

        public bool? isAcceptPayment { get; set; }

        public bool? isViewer { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset updatedAt { get; set; }

        public bool deleted { get; set; }

        public int sinif_id { get; set; }

        public virtual sinif sinif { get; set; }

        public virtual teacher teacher { get; set; }
    }
}
